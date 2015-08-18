using System;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe completar el Sexo.")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Debe completar la Fecha de Nacimiento.")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe completar la Altura.")]
        public string Altura { get; set; }

        [Required(ErrorMessage = "Debe completar la Complexión.")]
        public Complexion Complexion { get; set; }

        [Required(ErrorMessage = "Debe completar la Dieta.")]
        public Dieta Dieta { get; set; }

        [Required(ErrorMessage = "Debe completar su Preferencia Alimenticia.")]
        public PiramideAlimenticia PreferenciaAlimenticia { get; set; }

        [Required(ErrorMessage = "Debe completar la Rutina.")]
        public Rutina Rutina { get; set; }
    }
}