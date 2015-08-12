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
        //private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsuarioService(IUsuarioRepository usuariosRepository, /*ICategoryRepository categoryRepository,*/ IUnitOfWork unitOfWork)
        {
            this.usuariosRepository = usuariosRepository;
            //this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IUsuarioService Members

        public IEnumerable<Usuario> GetUsuarios()
        {
            var usuarios = usuariosRepository.GetAll();
            return usuarios;
        }

        //public IEnumerable<Usuario> GetCategoryUsuarios(string categoryName, string usuarioName = null)
        //{
        //    var category = categoryRepository.GetCategoryByName(categoryName);
        //    return category.Usuarios.Where(g => g.Name.ToLower().Contains(usuarioName.ToLower().Trim()));
        //}

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
            usuariosRepository.Add(usuario);
        }

        public void SaveUsuario()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
