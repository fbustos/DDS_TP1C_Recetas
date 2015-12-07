using System;
using DDS.Model.Models;
using System.Collections.Generic;
using DDS.Model.Enums;

namespace DDS.Service
{
    // operations you want to expose
    public interface IPlanificacionService
    {
        IEnumerable<Planificacion> GetPlanificaciones();
        Planificacion GetPlanificacion(int id);
        void CreatePlanificacion(Planificacion planificacion);
        void SavePlanificacion();

        bool VerificarDisponibilidad(Planificacion planificacion);

        IEnumerable<Planificacion> ObtenerPlanificadas(int id);

        IEnumerable<Planificacion> ObtenerPlanificadas10(int id);
    }
}
