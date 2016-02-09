using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public class Recomendaciones : IVisitor
    {
        public void Visit(Visitable visitable)
        {
            var condicion = visitable as Condicion;
            if (condicion != null)
            {
                condicion.Recomendaciones = string.Format("Se recomienda para su condición de {0} que antes de " +
                                                       "realizar las instrucciones de esta receta, consulte con su" +
                                                       "médico de cabecera.", condicion.Nombre);
            }
        }
    }
}
