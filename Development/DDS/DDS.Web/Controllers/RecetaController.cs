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
        public RecetaController(IRecetaService recetaService)
        {
            this.recetaService = recetaService;
        }
        public ActionResult CargarReceta()
        {
            return View();
        }

        // POST: Receta/Create
        [HttpPost]
        public ActionResult CargarReceta(CargarRecetaViewModel model)
        {
            if (ModelState.IsValid)
            {

                var receta = Mapper.Map<CargarRecetaViewModel, Receta>(model);
                recetaService.CreateReceta(receta);
                recetaService.SaveReceta();
                TempData["SuccessMessage"] = string.Format("Receta '{0}' cargado correctamente.", receta.Nombre);
            }

            return View(model);
        }
    }
}
