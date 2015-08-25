using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    // operations you want to expose
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        //IEnumerable<Usuario> GetCategoryUsuarios(string categoryName, string usuarioName = null);
        Usuario GetUsuario(int id);
        void CreateUsuario(Usuario usuario);
        void SaveUsuario();

        Usuario GetByUsername(string username);

        void UpdateUsuario(Usuario usuario);
    }
}
