using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public class Condicion : Visitable
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Recomendaciones { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }

        public virtual IList<Receta> Recetas { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
