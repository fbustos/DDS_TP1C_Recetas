using DDS.Model.Models;
using System.Collections.Generic;

namespace DDS.Service
{
    // operations you want to expose
    public interface IPlanificacionService
    {
        IEnumerable<Planificacion> GetPlanificaciones();
        Planificacion GetPlanificacion(int id);
        void CreatePlanificacion(Planificacion planificacion);
        void SavePlanificacion();
    }
}
