using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Models;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class PlanificacionViewModel
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public Categoria Categoria { get; set; }

        public Usuario Usuario { get; set; }
        public Receta Receta { get; set; }
    }
}