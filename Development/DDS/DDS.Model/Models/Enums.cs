using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Model.Enums
{
    public enum Complexion
    {
        Delgado = 1,
        Normal = 2,
        Sobrepeso = 3
    }

    public enum Dieta
    {
        Normal = 1,
        Ovolactovegetariano = 2,
        Vegetariano = 3,
        Vegano = 4
    }

    public enum Rutina
    {
        Leve = 1,
        Nada = 2,
        Mediano = 3,
        Intenso = 4,
        Normal = 5
    }

    public enum Sexo
    {
        [Description("Masculino")]
        M = 1,
        [Description("Femenino")]
        F = 2
    }

    public enum CondicionPreexistente
    { 
        Diabetes = 1,
        Hipertension = 2,
        Celiasis = 3
    }
}
