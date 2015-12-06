using DDS.Model.Enums;
using System;
using System.Collections.Generic;

namespace DDS.Model.Models
{
    public class Planificacion
    {
        public int Id { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Receta Receta { get; set; }

        public DateTime Fecha { get; set; }

        public Categoria Categoria { get; set; }
    }
}
