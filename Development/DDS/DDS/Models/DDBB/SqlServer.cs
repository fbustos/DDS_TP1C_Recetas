using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DDS.Models
{
    public class SqlServer
    {
        protected static SqlConnection conn = new SqlConnection();
        static SqlDataReader lector;
        public static string conexionString = "";

        public static SqlConnection Connect()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = conexionString;
                    conn.Open();
                }
                return conn;
            }
            catch (Exception e)
            {
                throw new DbException("No se pudo conectar con la base de datos", e);
            }
        }
        public static SqlConnection Connect(string newConexionString)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conexionString = newConexionString;
                    conn.ConnectionString = conexionString;
                    conn.Open();
                }
                return conn;
            }
            catch (DbException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DbException("No se pudo conectar con la base de datos", e);
            }
        }


        public static void Disconnect()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                throw new DbException("No se puede desconectar de la base de datos", e);
            }
        }

        public static SqlDataReader ExecuteQuery(string Consulta, List<SqlParameter> parametros)
        {
            Connect();

            try
            {
                SqlCommand comando = new SqlCommand(Consulta, conn);
                comando.CommandType = CommandType.Text;

                foreach (SqlParameter UnParametro in parametros)
                {
                    comando.Parameters.Add(UnParametro);
                }
                comando.Connection = Connect();
                return comando.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new DbException("No se logro ejecutar el comando", Consulta, parametros, e);
            }
        }

        public static SqlDataReader ExecuteQuery(string Consulta)
        {
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@ ", " "));
            return (ExecuteQuery(Consulta, Parametros));
        }

        public static int ExecuteNonQuery(string Consultas, List<SqlParameter> Parametros)
        {
            try
            {
                Connect();

                SqlCommand comando = new SqlCommand(Consultas, conn);

                comando.CommandType = CommandType.Text;
                foreach (SqlParameter Unparametro in (List<SqlParameter>)Parametros)
                {
                    comando.Parameters.Add(Unparametro);
                }
                comando.Connection = Connect();
                return comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DbException("No se logro ejecutar el comando", Consultas, Parametros, e);
            }
        }

        public static int GetLastId()
        {
            try
            {
                Connect();
                SqlCommand comando = new SqlCommand("SELECT @@IDENTITY", conn);
                return Convert.ToInt32(comando.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new DbException("No se logro recuperar el ultimo identificador", e);
            }
        }
    }
}
