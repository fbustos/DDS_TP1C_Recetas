using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Models
{
    public class ClassException : Exception
    {
        public string Clase = "";
        public string Metodo = "";

        public ClassException(string message, string clase, string metodo, Exception innerException)
            : base(message, innerException)
        {
            this.Clase = clase;
            this.Metodo = metodo;
        }

        public ClassException(string message, DbException innerException) : base(message, innerException) { }
    }
}
