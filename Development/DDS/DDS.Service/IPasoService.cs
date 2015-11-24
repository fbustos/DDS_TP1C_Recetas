using DDS.Model.Models;
using System.Collections.Generic;

namespace DDS.Service
{
    // operations you want to expose
    public interface IPasoService
    {
        IEnumerable<Paso> GetPasos();
        Paso Get(int id);
        void Create(Paso paso);
        void Save();
        void Update(Paso paso);
        void Delete(Paso paso);
    }
}
