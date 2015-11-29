using DDS.Model.Models;
using System.Collections.Generic;

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
        void DeleteReceta(Receta receta);
        IList<Ingrediente> GetIngredientes();
        IList<Condimento> GetCondimentos();
        Ingrediente GetIngredienteById(int id);
        Condimento GetCondimentoById(int id);
        IEnumerable<Receta> GetRecetasConfirmadas(int usuario);
    }
}
