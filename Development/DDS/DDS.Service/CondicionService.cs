using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    public class CondicionService : ICondicionService
    {
        private readonly ICondicionRepository condicionRepository;
        private readonly IUnitOfWork unitOfWork;

        public CondicionService(ICondicionRepository condicionRepository, IUnitOfWork unitOfWork)
        {
            this.condicionRepository = condicionRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IUsuarioService Members

        public IEnumerable<Condicion> GetCondiciones()
        {
            var condiciones = condicionRepository.GetAll();
            return condiciones;
        }

        public Condicion GetCondicion(int id)
        {
            var condicion = condicionRepository.GetById(id);
            return condicion;
        }

        public void SaveCondicion()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
