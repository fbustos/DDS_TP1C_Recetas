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
        Receta GetReceta(int id);
        void CreateReceta(Receta receta);
        void SaveReceta();
        void UpdateReceta(Receta receta);
        IList<Ingrediente> GetIngredientes();
        IList<Condimento> GetCondimentos();
        Ingrediente GetIngredienteById(int id);
        Condimento GetCondimentoById(int id);
    }
}
