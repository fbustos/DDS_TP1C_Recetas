using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DDS.Model.Enums;
using DDS.Model.Models;

namespace DDS.Models.ViewModels
{
    public class RecetaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe completar el Nombre.")]
        public string Nombre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Dificultad.")]
        public Dificultad Dificultad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la Temporada.")]
        public Temporada Temporada { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe completar las Calorias.")]
        public int Calorias { get; set; }

        [Display(Name = "Para personas con condición")]
        public int? Condicion { get; set; }

        public IList<Condicion> Condiciones { get; set; }

        public bool Desayuno { get; set; }

        public bool Almuerzo { get; set; }

        public bool Merienda { get; set; }

        public bool Cena { get; set; }

        public string IngredientesSeleccionados { get; set; }

        public string CondimentosSeleccionados { get; set; }

        public int CantidadVotos { get; set; }

        public int CalificacionAcumulador { get; set; }

        public string Recomendaciones { get; set; }

        public Usuario CreadaPor { get; set; }

        public IList<Ingrediente> Ingredientes { get; set; }

        public IList<Ingrediente> IngredientesDisponibles { get; set; }

        public IList<Condimento> Condimentos { get; set; }

        public IList<Condimento> CondimentosDisponibles { get; set; }

        public IList<UsuarioReceta> UsuarioRecetas { get; set; }

        public Calificacion Calificacion { get; set; }

        public Planificacion Planificacion { get; set; }

        public IList<Planificacion> Planificaciones { get; set; }

        public bool YaLaCalifique(int usuarioId)
        {
            var urec = UsuarioRecetas.FirstOrDefault(ur => ur.Usuario.Id == usuarioId);
            return urec != null && urec.Puntaje > 0;
        }

        public string Puntaje
        {
            get
            {
                return CantidadVotos > 0 ? String.Format("{0:0.##}", (double.Parse(CalificacionAcumulador.ToString()) / CantidadVotos)) : "0";
            }
        }
    }
}