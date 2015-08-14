using System;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de usuario.")]
        [Display(Name = "Nombre de Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe contener al menos {2} caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Las contraseñas ingresadas no coinciden.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe completar el Sexo.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Debe completar la Fecha de Nacimiento.")]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe completar la Altura.")]
        public string Altura { get; set; }

        [Required(ErrorMessage = "Debe completar la Complexión.")]
        public int? Complexion { get; set; }

        [Required(ErrorMessage = "Debe completar la Dieta.")]
        public int? Dieta { get; set; }

        [Required(ErrorMessage = "Debe completar su Preferencia Alimenticia.")]
        public int? PreferenciaAlimenticia { get; set; }

        [Required(ErrorMessage = "Debe completar la Rutina.")]
        public int? Rutina { get; set; }
    }
}