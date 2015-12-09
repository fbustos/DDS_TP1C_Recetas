using System.Linq;
using DDS.Model.Models;
using System.Collections.Generic;

namespace DDS.Service
{
    // operations you want to expose
    public interface IConsultaService
    {
        IEnumerable<Consulta> GetConsultas();
        Consulta GetConsulta(int id);
        void CreateConsulta(Consulta consulta);
        void SaveConsulta();

        IEnumerable<Receta> GetEntreFechas(System.DateTime? f1, System.DateTime? f2);

        IEnumerable<IGrouping<int, Receta>> GetEstadisticasSemanales(int? sexo, int? dificultad);

        IEnumerable<IGrouping<int, Receta>> GetEstadisticasMensuales(int? sexo, int? dificultad);
    }
}
