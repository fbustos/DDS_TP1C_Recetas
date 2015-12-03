using System.Linq;
using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;

namespace DDS.Service
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository consultasRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUnitOfWork unitOfWork;

        public ConsultaService(IConsultaRepository consultaRepository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            this.consultasRepository = consultaRepository;
            this.usuarioRepository = usuarioRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IConsultaService Members

        public IEnumerable<Consulta> GetConsultas()
        {
            var consultas = consultasRepository.GetAll();
            return consultas;
        }


        public Consulta GetConsulta(int id)
        {
            var consulta = consultasRepository.GetById(id);
            return consulta;
        }

        public void CreateConsulta(Consulta consulta)
        {
            consulta.FechaCreacion = DateTime.Now;
            consultasRepository.Add(consulta);
        }

        public void SaveConsulta()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
