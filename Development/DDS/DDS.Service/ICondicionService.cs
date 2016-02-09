using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Service
{
    // operations you want to expose
    public interface ICondicionService
    {
        IEnumerable<Condicion> GetCondiciones();
        Condicion GetCondicion(int id);
        void SaveCondicion();
    }
}
