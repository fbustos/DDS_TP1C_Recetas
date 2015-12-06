using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using DDS.Model.Enums;

namespace DDS.Service
{
    public class PlanificacionService : IPlanificacionService
    {
        private readonly IPlanificacionRepository planificacionesRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlanificacionService(IPlanificacionRepository planificacionRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            this.planificacionesRepository = planificacionRepository;
            this.usuarioRepository = usuarioRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPlanificacionService Members

        public IEnumerable<Planificacion> GetPlanificaciones()
        {
            var consultas = planificacionesRepository.GetAll();
            return consultas;
        }


        public Planificacion GetPlanificacion(int id)
        {
            var planificacion = planificacionesRepository.GetById(id);
            return planificacion;
        }

        public void CreatePlanificacion(Planificacion planificacion)
        {
            if (this.VerificarDisponibilidad(planificacion) == true)
            {
                planificacionesRepository.Add(planificacion);
            }
            
        }

        public void SavePlanificacion()
        {
            unitOfWork.Commit();
        }

        public bool VerificarDisponibilidad(Planificacion planificacion)
        {
            IEnumerable<Planificacion> planificaciones = planificacionesRepository.GetAll()
                .Where(
                        x => 
                            x.Receta.Id == planificacion.Receta.Id
                            && x.Usuario.Id == planificacion.Usuario.Id 
                            && x.Fecha.Day == planificacion.Fecha.Day
                            && x.Fecha.Month == planificacion.Fecha.Month
                            && x.Fecha.Year == planificacion.Fecha.Year
                            && x.Categoria.ToString() == planificacion.Categoria.ToString()
                 );
            if (planificaciones.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<Planificacion> ObtenerPlanificadas(int id)
        {
            return planificacionesRepository.GetAll()
                .Where(x => x.Usuario.Id == id)
                .OrderByDescending(x => x.Fecha)
                .ThenBy(x => x.Categoria);
        }

        #endregion

    }
}
