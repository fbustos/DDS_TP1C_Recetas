using DDS.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Models
{
    public class Perfil
    {
        public string Nombre { get; set; }

        public Sexo Sexo { get; set; }

        public int Edad { get; set; }

        public float Altura { get; set; }

        public Complexion Complexion { get; set; }

        public Dieta Dieta { get; set; }

        public int PreferenciaAlimenticiaId { get; set; }
        public PiramideAlimenticia PreferenciaAlimenticia { get; set; }

        public Rutina Rutina { get; set; }
    }
}
