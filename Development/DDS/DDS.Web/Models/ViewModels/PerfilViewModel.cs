using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;
using DDS.Model.Models;

namespace DDS.Models.ViewModels
{
    public class PerfilViewModel
    {
        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione el Sexo")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Debe completar la Fecha de Nacimiento.")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe completar la Altura.")]
        public float Altura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Complexion")]
        public Complexion Complexion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Dieta")]
        public Dieta Dieta { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Preferencia Alimenticia")]
        [Display(Name = "Preferencia Alimenticia")]
        public PiramideAlimenticia PreferenciaAlimenticia { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Rutina")]
        public Rutina Rutina { get; set; }

        [Display(Name = "Condición Preexistente")]
        public int? Condicion { get; set; }

        public IList<Condicion> Condiciones { get; set; }
    }
}