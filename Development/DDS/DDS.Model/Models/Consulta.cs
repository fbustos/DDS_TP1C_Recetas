using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS.Model.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public int IdReceta { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
