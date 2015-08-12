using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS.Model.Models
{
    public class Condimento
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Tipo { get; set; }

        public virtual IList<Receta> Recetas { get; set; }
    }
}
