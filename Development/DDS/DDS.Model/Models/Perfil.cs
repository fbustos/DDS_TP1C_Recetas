using DDS.Model.Enums;
using System;

namespace DDS.Model.Models
{
    public class Perfil
    {
        public string Nombre { get; set; }

        public Sexo? Sexo { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public float Altura { get; set; }

        public Complexion? Complexion { get; set; }

        public Dieta? Dieta { get; set; }

        public PiramideAlimenticia? PreferenciaAlimenticia { get; set; }

        public Rutina? Rutina { get; set; }

        public int? Edad
        {
            get
            {
                if (!this.FechaNacimiento.HasValue)
                    return null;

                var now = DateTime.Today;
                int age = now.Year - this.FechaNacimiento.Value.Year;
                if (now < this.FechaNacimiento.Value.AddYears(age)) age--;
                return age;
            }
        }
    }
}
