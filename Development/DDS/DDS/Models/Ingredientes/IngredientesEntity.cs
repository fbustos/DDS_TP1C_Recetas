using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDS.Models.Ingredientes
{
    public class IngredientesEntity
    {
        private int calorias;
        public int Calorias
        {
            get { return calorias; }
            set { calorias = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int porcion;
        public int Porcion
        {
            get { return porcion; }
            set { porcion = value; }
        }
    }
}