using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS.Model.Models
{
    public class Paso
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public virtual IList<Receta> Recetas { get; set; }
    }
}
