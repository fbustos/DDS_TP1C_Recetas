using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class EstadisticaViewModel
    {
        public bool Semanal { get; set; }

        public Sexo Sexo { get; set; }

        public Dificultad Dificultad { get; set; }
    }
}