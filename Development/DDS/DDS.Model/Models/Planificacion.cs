using DDS.Model.Enums;
using System;
using System.Collections.Generic;

namespace DDS.Model.Models
{
    public class Planificacion
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public Receta Receta { get; set; }

        public DateTime Fecha { get; set; }

        public Categoria Categoria { get; set; }
    }
}
