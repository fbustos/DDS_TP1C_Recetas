using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDS.Models
{
    public class PerfilUsuarioEntity
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string contrasenia;
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        private int altura;
        public int Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        private Complexion complexion;
        public Complexion Complexion
        {
            get { return complexion; }
            set { complexion = value; }
        }

        private Dieta dieta;
        public Dieta Dieta
        {
            get { return dieta; }
            set { dieta = value; }
        }

        private DateTime fecha_nacimiento;
        public DateTime FechaNacimiento
        {
            get { return fecha_nacimiento; }
            set { fecha_nacimiento = value; }
        }

        private int medida_cadera;

        public int MedidaCadera
        {
            get { return medida_cadera; }
            set { medida_cadera = value; }
        }

        private int medida_cintura;
        public int MedidaCintura
        {
            get { return medida_cintura; }
            set { medida_cintura = value; }
        }

        private int medida_torax;
        public int MedidaTorax
        {
            get { return medida_torax; }
            set { medida_torax = value; }
        }

        private float peso;
        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        private Rutina rutina;
        public Rutina Rutina
        {
            get { return rutina; }
            set { rutina = value; }
        }

        private Sexo sexo;
        public Sexo Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

    }

    public enum Complexion{
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

    public enum Rutina{
        Leve = 1,
        Nada = 2,
        Mediano = 3,
        Intenso = 4,
        Normal = 5
    }

    public enum Sexo
    {
        Masculino = 1,
        Femenino = 2
    }
}