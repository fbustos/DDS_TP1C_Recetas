using AutoMapper;
using DDS.Model.Models;
using DDS.Models.ViewModels;
using DDS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDS.Controllers
{
    public class RecetaController : BaseController
    {
        private readonly IRecetaService recetaService;
        private readonly IUsuarioService usuarioService;
        public RecetaController(IRecetaService recetaService, IUsuarioService usuarioService)
        {
            this.recetaService = recetaService;
            this.usuarioService = usuarioService;
        }

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
            int? id = null;
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
                    recetaBd.Ingredientes = receta.Ingredientes;
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
                id = receta.Id;
                TempData["SuccessMessage"] = string.Format("Receta '{0}' cargada correctamente.", receta.Nombre);
            }
            return RedirectToAction("CargarReceta", new { id });
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
