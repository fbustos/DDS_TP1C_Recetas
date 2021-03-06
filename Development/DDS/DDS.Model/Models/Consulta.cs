﻿using System;

namespace DDS.Model.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public virtual Receta Receta { get; set; }

        public virtual Usuario Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
