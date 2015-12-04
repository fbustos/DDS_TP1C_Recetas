using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Masculino")]
        M = 1,
        [Display(Name = "Femenino")]
        F = 2
    }

    public enum CondicionPreexistente
    { 
        Diabetes = 1,
        Hipertension = 2,
        Celiasis = 3
    }

    public enum Dificultad
    {
        Facil = 1,
        Media = 2,
        Dificil = 3,
        MuyDificil = 4
    }

    public enum PiramideAlimenticia
    {
        Vegetales = 1,
        Lacteos = 2,
        Carnes = 3,
        Dulces = 4
    }

    public enum Temporada
    {
        Verano = 1,
        Otonio = 2,
        Invierno = 3,
        Primavera = 4
    }

    public enum Categoria
    {
        Desayuno = 1,
        Almuerzo = 2,
        Merienda = 3,
        Cena = 4
    }

    public enum Calificacion
    {
        [Display(Name = "5 - Excelente")]
        Excelente = 5,
        [Display(Name = "4 - Muy buena")]
        MuyBuena = 4,
        [Display(Name = "3 - buena")]
        Buena = 3,
        [Display(Name = "2 - Regular")]
        Regular = 2,
        [Display(Name = "1 - Mala")]
        Mala = 1,
    }
}
