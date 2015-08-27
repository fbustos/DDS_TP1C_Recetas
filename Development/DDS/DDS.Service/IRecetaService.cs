using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    // operations you want to expose
    public interface IRecetaService
    {
        IEnumerable<Receta> GetRecetas();
        //IEnumerable<Usuario> GetCategoryUsuarios(string categoryName, string usuarioName = null);
        Receta GetReceta(int id);
        void CreateReceta(Receta receta);
        void SaveReceta();

        void UpdateReceta(Receta receta);
    }
}
