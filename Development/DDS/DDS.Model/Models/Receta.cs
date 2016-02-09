using System;
using System.Collections.Generic;
using DDS.Model.Enums;

namespace DDS.Model.Models
{
    public class Receta
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Dificultad Dificultad { get; set; }

        public Temporada Temporada { get; set; }

        public int Calorias { get; set; }

        public bool Desayuno { get; set; }

        public bool Almuerzo { get; set; }

        public bool Merienda { get; set; }

        public bool Cena { get; set; }

        public int CantidadVotos { get; set; }

        public int CalificacionAcumulador { get; set; }

        public virtual IList<Ingrediente> Ingredientes { get; set; }

        public virtual IList<Condimento> Condimentos { get; set; }

        public virtual IList<Paso> Pasos { get; set; }

        public virtual Usuario CreadaPor { get; set; }

        public virtual IList<UsuarioReceta> UsuarioRecetas { get; set; } 

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaUltimaModificacion { get; set; }

        public virtual IList<Consulta> Consultas { get; set; }

        public virtual IList<Planificacion> Planificaciones { get; set; }

        public virtual Condicion Condicion { get; set; }
    }
}
