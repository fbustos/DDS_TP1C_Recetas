using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DDS.Model.Models;

namespace DDS.Models.ViewModels
{
    public class GrupoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe completar el Nombre.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}