using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public class Receta
    {
        public int Id { get; set; }

        public virtual IList<Ingrediente> Ingredientes { get; set; }

        public virtual IList<Condimento> Condimentos { get; set; }

        public virtual IList<Paso> Pasos { get; set; } 
    }
}
