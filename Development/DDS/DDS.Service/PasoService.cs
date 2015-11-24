using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;

namespace DDS.Service
{
    public class PasoService : IPasoService
    {
        private readonly IPasoRepository pasosRepository;
        private readonly IUnitOfWork unitOfWork;

        public PasoService(IPasoRepository pasosRepository, IUnitOfWork unitOfWork)
        {
            this.pasosRepository = pasosRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IPasoService Members

        public IEnumerable<Paso> GetPasos()
        {
            var pasos = pasosRepository.GetAll();
            return pasos;
        }

        public Paso Get(int id)
        {
            var paso = pasosRepository.GetById(id);
            return paso;
        }

        public void Create(Paso paso)
        {
            pasosRepository.Add(paso);
        }

        public void Update(Paso paso)
        {
            pasosRepository.Update(paso);
        }

        public void Delete(Paso paso)
        {
            pasosRepository.Delete(paso);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
