using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Hosting;
using System.Web.Routing;
using Antlr.Runtime.Misc;
using AutoMapper;
using DDS.Model.Models;
using DDS.Models.ViewModels;
using DDS.Service;
using System.Linq;
using System.Web.Mvc;

namespace DDS.Controllers
{
    public class RecetaController : BaseController
    {
        private readonly IRecetaService recetaService;
        private readonly IUsuarioService usuarioService;
        private readonly IPasoService pasoService;

        public RecetaController(IRecetaService recetaService, IUsuarioService usuarioService, IPasoService pasoService)
        {
            this.recetaService = recetaService;
            this.usuarioService = usuarioService;
            this.pasoService = pasoService;
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
                }
                else
                {
                    var recetaBd = recetaService.GetReceta(receta.Id);
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
                }

                recetaService.SaveReceta();
                TempData["SuccessMessage"] = string.Format("Receta '{0}' cargada correctamente.", receta.Nombre);
                
                return RedirectToAction("_CargarPaso", new { recetaId = receta.Id, nroPaso = 0 });
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
            return RedirectToAction("CargarReceta", new {id = model.RecetaId});
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

        public ActionResult VerRecetas()
        {
            return null;
        }

        #endregion

        public ActionResult Delete(int id)
        {
            var receta = recetaService.GetReceta(id);
            recetaService.DeleteReceta(receta);
            recetaService.SaveReceta();

            return RedirectToAction("MisRecetas");
        }

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
