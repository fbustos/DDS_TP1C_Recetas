using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS.Model.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Porcion { get; set; }

        public double CaloriasPorcion { get; set; }

        public virtual IList<Receta> Recetas { get; set; }
    }
}
