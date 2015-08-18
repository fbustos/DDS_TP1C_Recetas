using System;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Enums;

namespace DDS.Models.ViewModels
{
    public class RegisterViewModel
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
    }
}