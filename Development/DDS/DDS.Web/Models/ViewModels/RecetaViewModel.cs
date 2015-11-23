using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;
using DDS.Model.Models;

namespace DDS.Models.ViewModels
{
    public class RecetaViewModel
    {
        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Dificultad.")]
        public Dificultad Dificultad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Temporada.")]
        public Temporada Temporada { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe completar las Calorias.")]
        public int Calorias { get; set; }

        public bool Desayuno { get; set; }

        public bool Almuerzo { get; set; }

        public bool Merienda { get; set; }

        public bool Cena { get; set; }

        public IList<Ingrediente> Ingredientes { get; set; }

        public IList<Condimento> Condimentos { get; set; }
    }
}