using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }

        public int CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
