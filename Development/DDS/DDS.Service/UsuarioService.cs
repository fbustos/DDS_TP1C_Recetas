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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuariosRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsuarioService(IUsuarioRepository usuariosRepository, IUnitOfWork unitOfWork)
        {
            this.usuariosRepository = usuariosRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IUsuarioService Members

        public IEnumerable<Usuario> GetUsuarios()
        {
            var usuarios = usuariosRepository.GetAll();
            return usuarios;
        }

        public Usuario GetUsuario(int id)
        {
            var usuario = usuariosRepository.GetById(id);
            return usuario;
        }

        public Usuario GetByUsername(string username)
        {
            var usuario = usuariosRepository.Get(u => u.Username == username);
            return usuario;
        }

        public void CreateUsuario(Usuario usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            usuariosRepository.Add(usuario);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            usuario.FechaUltimaModificacion = DateTime.Now;
            usuariosRepository.Update(usuario);
        }

        public void SaveUsuario()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
