using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDS.Model.Enums;

namespace DDS.Model.Models
{
    public class Receta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Dificultad Dificultad { get; set; }

        public Temporada Temporada { get; set; }

        public int Calorias { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaUltimaModificacion { get; set; }
    }
}
