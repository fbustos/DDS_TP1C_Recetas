using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Models
{
    [Serializable]
    public class DbException : Exception
    {
        public string consulta = "";
        public List<SqlParameter> parametros = new List<SqlParameter>();


        public DbException(string message, string consult, List<SqlParameter> parametrosConsulta, Exception innerException)
            : base(message, innerException)
        {
            this.consulta = consult;
            this.parametros = parametrosConsulta;
        }

        public DbException(string message, Exception innerException) : base(message, innerException) { }
    }
}
