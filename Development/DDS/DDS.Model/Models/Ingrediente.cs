using System.Collections.Generic;

namespace DDS.Model.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Porcion { get; set; }

        public int CaloriasPorcion { get; set; }

        public virtual IList<Receta> Recetas { get; set; }
    }
}
