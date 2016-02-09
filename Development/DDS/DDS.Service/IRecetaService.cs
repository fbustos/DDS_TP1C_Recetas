using DDS.Model.Enums;
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
        IEnumerable<Receta> GetNuevas();
        IEnumerable<Receta> GetPorCalorias(int? cal1, int? cal2);
        IEnumerable<Receta> GetConfirmadasEntreFechas(System.DateTime? f1, System.DateTime? f2);

        IEnumerable<Receta> GetFiltradas(int? Calorias, Temporada? Temporada, Dificultad? Dificultad, Condicion condicion);
    }
}
