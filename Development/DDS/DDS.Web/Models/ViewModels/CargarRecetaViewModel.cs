using System;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class CargarRecetaViewModel
    {
        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Dificultad.")]
        public Dificultad Dificultad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Temporada.")]
        public Temporada Temporada { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe completar las Calorias.")]
        public int Calorias { get; set; }
    }
}