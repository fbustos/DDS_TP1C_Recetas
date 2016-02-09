using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDS.Models.Security;
using DDS.Service;
using DDS.Model.Models;
using DDS.Models.ViewModels;
using AutoMapper;

namespace DDS.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        private readonly IRecetaService recetaService;
        private readonly IUsuarioService usuarioService;
        private readonly IPlanificacionService planificacionService;

        public HomeController(IRecetaService recetaService, IUsuarioService usuarioService, IPlanificacionService planificacionService)
        {
            this.recetaService = recetaService;
            this.usuarioService = usuarioService;
            this.planificacionService = planificacionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            var recetas = new List<Receta>();
            IEnumerable<Planificacion> planificaciones = planificacionService.ObtenerPlanificadas10(Current.User.Id).ToList();
            if (planificaciones.Any())
            {
                recetas.AddRange(planificaciones.Select(planificacion => planificacion.Receta));
            }
            else
            {
                Usuario usuario = usuarioService.GetUsuario(Current.User.Id);
                recetas = usuario.UsuarioRecetas.OrderByDescending(x => x.Fecha).Take(10).Select(x => x.Receta).ToList();
                if (!recetas.Any())
                {
                    if (usuario.Condicion != null)
                    {
                        recetas = recetaService.GetRecetas().Where(x => x.Condicion != null && x.Condicion.Id == usuario.Condicion.Id).Take(10).ToList();
                    }
                    else
                    {
                        recetas = recetaService.GetRecetas().Where(x => x.CantidadVotos > 0).OrderBy(x => (x.CalificacionAcumulador / x.CantidadVotos)).Take(10).ToList();
                    }
                }
            }

            var model = Mapper.Map<IEnumerable<Receta>, IEnumerable<RecetaViewModel>>(recetas);

            return View(model);
        }
    }
}