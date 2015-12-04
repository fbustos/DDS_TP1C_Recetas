using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;

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
            planificacionesRepository.Add(planificacion);
        }

        public void SavePlanificacion()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
