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
    }
}
