using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using DDS.Model.Models;
using DDS.Models.Security;
using DDS.Service;

namespace DDS.Controllers
{
    [CustomAuthorize]
    public class EstadisticaController : BaseController
    {
        private readonly IRecetaService recetaService;
        private readonly IConsultaService consultaService;

        public EstadisticaController(IRecetaService recetaService, IConsultaService consultaService)
        {
            this.recetaService = recetaService;
            this.consultaService = consultaService;
        }

        // GET: Estadistica
        public ActionResult Estadistica()
        {
            return View();
        }

        public PartialViewResult GetEstadisticas(bool semanal, int? sexo, int? dificultad)
        {
            var dic = new Dictionary<string,IEnumerable<Receta>>();
            if (semanal)
            {
                dic = this.consultaService.GetEstadisticasSemanales(sexo, dificultad)
                    .ToDictionary(x => "Semana " + x.Key + " | Cantidad de Consultas: " + x.Count(), y => y.Select(z => z));
            }
            else
            {
                dic = this.consultaService.GetEstadisticasMensuales(sexo, dificultad)
                    .ToDictionary(x => "Mes " + x.Key + " | Cantidad de Consultas: " + x.Count(), y => y.Select(z => z));
            }

            return PartialView("_ResultadoBusqueda", dic);
        }
    }
}