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
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly IUnitOfWork unitOfWork;

        public GrupoService(IGrupoRepository grupoRepository, IUnitOfWork unitOfWork)
        {
            this.grupoRepository = grupoRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IUsuarioService Members

        public IEnumerable<Grupo> GetGrupos()
        {
            var grupos = grupoRepository.GetAll();
            return grupos;
        }

        public IEnumerable<Grupo> GetGruposPorUsuarioUnido(int id)
        {
            var grupos = this.GetGrupos().Where(g => g.Usuarios.Any(u => u.Id == id));
            return grupos;
        }

        public IEnumerable<Grupo> GetGruposByUserId(int id)
        {
            var grupos = this.GetGrupos().Where(g => g.CreadoPor == id);
            return grupos;
        }

        public Grupo GetGrupo(int id)
        {
            var grupo = grupoRepository.GetById(id);
            return grupo;
        }

        public void CreateGrupo(Grupo grupo)
        {
            grupo.FechaCreacion = DateTime.Now;
            grupoRepository.Add(grupo);
        }

        public void UpdateGrupo(Grupo grupo)
        {
            var elGrupo = this.GetGrupo(grupo.Id);
            elGrupo.Nombre = grupo.Nombre;
            elGrupo.Descripcion = grupo.Descripcion;
            elGrupo.FechaModificacion = DateTime.Now;
            
            grupoRepository.Update(elGrupo);
        }

        public void SaveGrupo()
        {
            unitOfWork.Commit();
        }

        public void DeleteGrupo(Grupo grupo)
        {
            grupoRepository.Delete(grupo);
        }

        #endregion

    }
}
