﻿using System;

namespace DDS.Model.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        public Receta Receta { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}