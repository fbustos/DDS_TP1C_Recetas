using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Hosting;
using AutoMapper;
using DDS.Model.Enums;
using DDS.Model.Models;
using DDS.Models.Security;
using DDS.Models.ViewModels;
using DDS.Service;
using System.Linq;
using System.Web.Mvc;

namespace DDS.Controllers
{
    [CustomAuthorize]
    public class RecetaController : BaseController
    {
        private readonly IRecetaService recetaService;
        private readonly IUsuarioService usuarioService;
        private readonly IPasoService pasoService;
        private readonly IConsultaService consultaService;
        private readonly IPlanificacionService planificacionService;

        public RecetaController(IRecetaService recetaService, IUsuarioService usuarioService, IPasoService pasoService, IConsultaService consultaService, IPlanificacionService planificacionService)
        {
            this.recetaService = recetaService;
            this.usuarioService = usuarioService;
            this.pasoService = pasoService;
            this.consultaService = consultaService;
            this.planificacionService = planificacionService;
        }

        #region Cargar Receta

        public ActionResult CargarReceta(int? id = null)
        {
            var model = new RecetaViewModel();

            if (id.HasValue)
            {
                var receta = this.recetaService.GetReceta(id.Value);
                model = Mapper.Map<Receta, RecetaViewModel>(receta);
            }

            model.IngredientesDisponibles = this.recetaService.GetIngredientes();
            model.CondimentosDisponibles = this.recetaService.GetCondimentos();

            return View(model);
        }

        // POST: Receta/Create
        [HttpPost]
        public ActionResult CargarReceta(RecetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receta = Mapper.Map<RecetaViewModel, Receta>(model);
                this.GuardarIngredientes(model, receta);
                this.GuardarCondimentos(model, receta);
                if (model.Id == 0)
                {
                    receta.CreadaPor = usuarioService.GetByUsername(Current.User.Username);
                    recetaService.CreateReceta(receta);

                    recetaService.SaveReceta();
                    TempData["SuccessMessage"] = string.Format("Receta '{0}' cargada correctamente.", receta.Nombre);

                    return RedirectToAction("_CargarPaso", new { recetaId = receta.Id, nroPaso = 0 });
                }
                else
                {
                    var recetaBd = recetaService.GetReceta(receta.Id);
                    

                    if (recetaBd.CreadaPor.Id != Current.User.Id)
                    {
                        Receta unaReceta = new Receta
                        {
                            Ingredientes = receta.Ingredientes,
                            Condimentos = receta.Condimentos,
                            Cena = receta.Cena,
                            Almuerzo = receta.Almuerzo,
                            Merienda = receta.Merienda,
                            Desayuno = receta.Desayuno,
                            Nombre = receta.Nombre,
                            Calorias = receta.Calorias,
                            Dificultad = receta.Dificultad,
                            CreadaPor = usuarioService.GetUsuario(Current.User.Id),
                            Temporada = receta.Temporada
                        };
                        recetaService.CreateReceta(unaReceta);
                        recetaService.SaveReceta();
                        TempData["SuccessMessage"] = string.Format("Receta '{0}' cargada correctamente.", unaReceta.Nombre);

                        return RedirectToAction("_CargarPaso", new { recetaId = unaReceta.Id, nroPaso = 0 });
                    }
                    else
                    {
                        recetaBd.Ingredientes.Clear();
                        recetaBd.Ingredientes = receta.Ingredientes;
                        recetaBd.Condimentos.Clear();
                        recetaBd.Condimentos = receta.Condimentos;
                        recetaBd.Cena = receta.Cena;
                        recetaBd.Almuerzo = receta.Almuerzo;
                        recetaBd.Merienda = receta.Merienda;
                        recetaBd.Desayuno = receta.Desayuno;
                        recetaBd.Nombre = receta.Nombre;
                        recetaBd.Calorias = receta.Calorias;
                        recetaBd.Dificultad = receta.Dificultad;
                        recetaService.UpdateReceta(recetaBd);

                        recetaService.SaveReceta();
                        TempData["SuccessMessage"] = string.Format("Receta '{0}' cargada correctamente.", receta.Nombre);

                        return RedirectToAction("_CargarPaso", new { recetaId = receta.Id, nroPaso = 0 });
                    }
                    
                }
            }

            model.IngredientesDisponibles = this.recetaService.GetIngredientes();
            model.CondimentosDisponibles = this.recetaService.GetCondimentos();
            return View(model);
        }

        public ActionResult _CargarPaso(int recetaId, int nroPaso)
        {
            var model = new PasoViewModel();
            var receta = recetaService.GetReceta(recetaId);
            if (receta.Pasos != null && receta.Pasos.Any())
            {
                Paso paso = receta.Pasos.FirstOrDefault(p => p.Numero == nroPaso);
                if (paso != null)
                {
                    model = Mapper.Map<Paso, PasoViewModel>(paso);
                    model.ImagenPath = this.GetImagePath(model);   
                }
            }

            model.Numero = nroPaso;
            model.RecetaId = recetaId;
            if (nroPaso == 0)
            {
                TempData["BotonVolver"] = Url.Action("CargarReceta", new { id = recetaId });
            }
            else
            {
                TempData["BotonVolver"] = Url.Action("_CargarPaso", new { recetaId, nroPaso = (nroPaso - 1) });
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult _CargarPaso(PasoViewModel model)
        {
            var paso = Mapper.Map<PasoViewModel, Paso>(model);
            paso.ImagenPath = model.Imagen != null ? this.GuardarImagen(model) : model.ImagenPath;
            var receta = this.recetaService.GetReceta(model.RecetaId);
            if (model.Id == 0)
            {
                receta.Pasos.Add(paso);
                recetaService.UpdateReceta(receta);
                recetaService.SaveReceta();
            }
            else
            {
                var pasoBd = pasoService.Get(model.Id);
                pasoService.Delete(pasoBd);
                paso.Receta = receta;
                pasoService.Create(paso);
                pasoService.Save();
            }

            if (paso.Numero <= 3)
            {
                TempData["SuccessMessage"] = string.Format("Se han cargado correctamente el Paso {0}", model.Numero + 1);
                return RedirectToAction("_CargarPaso", new { recetaId = model.RecetaId, nroPaso = (model.Numero + 1) });
            }

            TempData["SuccessMessage"] = string.Format("Se han cargado todos los pasos correctamente");
            return RedirectToAction("CargarReceta", new { id = model.RecetaId });
        }

        #endregion

        #region Mis Recetas

        // GET: Grupo/MisGrupos
        public ActionResult MisRecetas()
        {
            var recetas = this.recetaService.GetRecetas().Where(r => r.CreadaPor.Id == this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Receta>, IList<RecetaViewModel>>(recetas);
            return View(model);
        }

        public ActionResult Planificaciones()
        {
            var planificaciones = this.planificacionService.ObtenerPlanificadas(this.Current.User.Id);
            var model = Mapper.Map<IEnumerable<Planificacion>, IList<PlanificacionViewModel>>(planificaciones);
            return View(model);
        }

        #endregion

        public ActionResult Delete(int id)
        {
            var receta = recetaService.GetReceta(id);
            recetaService.DeleteReceta(receta);
            recetaService.SaveReceta();

            return RedirectToAction("MisRecetas");
        }

        public ActionResult Details(int id)
        {
            Receta receta = recetaService.GetReceta(id);

            Consulta consulta = new Consulta();
            consulta.Receta = receta;
            consulta.Usuario = usuarioService.GetUsuario(Current.User.Id);
            consultaService.CreateConsulta(consulta);
            consultaService.SaveConsulta();

            var model = Mapper.Map<Receta, RecetaViewModel>(receta);
            var usuarioReceta = receta.UsuarioRecetas.FirstOrDefault(ur => ur.Usuario.Id == Current.User.Id);
            if (usuarioReceta != null)
            {
                model.Calificacion = (Calificacion)usuarioReceta.Puntaje;
            }

            return View(model);
        }

        public ActionResult Calificar(int id, int calificacion)
        {
            var receta = recetaService.GetReceta(id);
            var usuarioReceta = receta.UsuarioRecetas.FirstOrDefault(ur => ur.Usuario.Id == Current.User.Id);
            
            if (usuarioReceta != null)
            {
                usuarioReceta.Puntaje = calificacion;
            }
            else
            {
                var ur = new UsuarioReceta
                {
                    Receta = receta,
                    Puntaje = calificacion,
                    Usuario = usuarioService.GetUsuario(Current.User.Id),
                    Fecha = DateTime.Now
                };

                receta.UsuarioRecetas.Add(ur);
            }

            receta.CantidadVotos++;
            receta.CalificacionAcumulador += calificacion;
            recetaService.UpdateReceta(receta);
            recetaService.SaveReceta();

            TempData["SuccessMessage"] = string.Format("Receta '{0}' calificada correctamente con: {1}", receta.Nombre, calificacion);

            return RedirectToAction("Details", new { id });
        }

        public ActionResult Planificar(RecetaViewModel model)
        {
            var receta = recetaService.GetReceta(model.Id);
            var usuario = usuarioService.GetUsuario(Current.User.Id);

            Planificacion planificacion = new Planificacion
            {
                Receta = receta,
                Usuario = usuario,
                Fecha = model.Planificacion.Fecha,
                Categoria = model.Planificacion.Categoria
            };

            if (planificacionService.VerificarDisponibilidad(planificacion))
            {
                bool flagComida = false;
                switch ((int)planificacion.Categoria)
                {
                    case 1:
                        if (receta.Desayuno == true)
                        {
                            flagComida = true;
                        }
                        break;
                    case 2:
                        if (receta.Almuerzo == true)
                        {
                            flagComida = true;
                        }
                        break;
                    case 3:
                        if (receta.Merienda == true)
                        {
                            flagComida = true;
                        }
                        break;
                    case 4:
                        if (receta.Cena == true)
                        {
                            flagComida = true;
                        }
                        break;

                }

                if (flagComida == true)
                {
                    planificacionService.CreatePlanificacion(planificacion);
                    planificacionService.SavePlanificacion();

                    TempData["SuccessMessage"] = "La receta fue planificada correctamente";
                }
                else
                {
                    TempData["ErrorMessage"] = "La receta no esta disponible para la categoria seleccionada.";
                }
                
            }
            else
            {
                TempData["ErrorMessage"] = "La receta no puede ser planificada para la fecha y categoria seleccionadas. Esa comida ya esta planeada.";
            }
            

            return RedirectToAction("Details", new { model.Id });
        }

        #region Buscar

        public ActionResult Buscar()
        {
            return View("Buscar/PorPeriodo");
        }

        public PartialViewResult BuscarPorPeriodo(DateTime? f1, DateTime? f2)
        {
            var recetas = consultaService.GetEntreFechas(f1, f2);
            var model = Mapper.Map<IEnumerable<Receta>, IList<RecetaViewModel>>(recetas);
            return PartialView("Buscar/_ResultadoBusqueda", model);
        }

        public PartialViewResult BuscarNuevas()
        {
            var recetas = recetaService.GetNuevas();
            var model = Mapper.Map<IEnumerable<Receta>, IList<RecetaViewModel>>(recetas);
            return PartialView("Buscar/_ResultadoBusqueda", model);
        }

        public PartialViewResult BuscarPorCalorias(int? cal1, int? cal2)
        {
            var recetas = recetaService.GetPorCalorias(cal1, cal2);
            var model = Mapper.Map<IEnumerable<Receta>, IList<RecetaViewModel>>(recetas);
            return PartialView("Buscar/_ResultadoBusqueda", model);
        }

        public PartialViewResult BuscarPreferenciasPorPeriodo(DateTime? f1, DateTime? f2)
        {
            var recetas = recetaService.GetConfirmadasEntreFechas(f1, f2);
            var model = Mapper.Map<IEnumerable<Receta>, IList<RecetaViewModel>>(recetas);
            return PartialView("Buscar/_ResultadoBusqueda", model);
        }

        #endregion

        private string GetImagePath(PasoViewModel model)
        {
            string pathImages = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["UploadedImagesPath"]);
            string siteImagesPath = Path.Combine(pathImages, model.Code);
            string noImage = "#";
            if (!Directory.Exists(siteImagesPath))
            {
                return noImage;
            }

            foreach (var file in Directory.GetFiles(siteImagesPath))
            {
                if (Path.GetFileNameWithoutExtension(file) == model.NombreImagen)
                {
                    return ConfigurationManager.AppSettings["UploadedImagesUrl"] + "//" + model.Code + "//" + model.NombreImagen + Path.GetExtension(file);
                }
            }

            return noImage;
        }

        private string GuardarImagen(PasoViewModel model)
        {
            string newImagePath = string.Empty;
            if (model.Imagen != null && model.Imagen.ContentLength > 0)
            {
                var pathImages = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["UploadedImagesPath"]);
                if (pathImages != null)
                {
                    var siteImagesPath = Path.Combine(pathImages, model.Code);
                    if (!Directory.Exists(siteImagesPath))
                    {
                        Directory.CreateDirectory(siteImagesPath);
                    }

                    var files = Directory.GetFiles(siteImagesPath);
                    foreach (var f in files.Where(f => Path.GetFileNameWithoutExtension(f) == model.NombreImagen))
                    {
                        System.IO.File.Delete(f);
                    }

                    newImagePath = Path.Combine(siteImagesPath, model.NombreImagen + Path.GetExtension(model.Imagen.FileName));

                    using (var bitmap = (Bitmap)Image.FromStream(model.Imagen.InputStream))
                    {
                        using (var newBitmap = new Bitmap(bitmap))
                        {
                            newBitmap.SetResolution(500, 300);
                            newBitmap.Save(newImagePath, ImageFormat.Jpeg);
                        }
                    }
                }
            }

            return newImagePath;
        }

        private void GuardarCondimentos(RecetaViewModel model, Receta receta)
        {
            if (!string.IsNullOrEmpty(model.CondimentosSeleccionados))
            {
                var idCondimentos = model.CondimentosSeleccionados.Split(',').Select(int.Parse).ToList();
                receta.Condimentos = idCondimentos.Select(x => recetaService.GetCondimentoById(x)).ToList();
            }
        }

        private void GuardarIngredientes(RecetaViewModel model, Receta receta)
        {
            if (!string.IsNullOrEmpty(model.IngredientesSeleccionados))
            {
                var idIngredientes = model.IngredientesSeleccionados.Split(',').Select(int.Parse).ToList();
                receta.Ingredientes = idIngredientes.Select(x => recetaService.GetIngredienteById(x)).ToList();
            }
        }
    }
}
