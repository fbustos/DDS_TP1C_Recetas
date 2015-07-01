using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DDS.Models.PerfilUsuario
{
    public class PerfilUsuarioControl
    {
        public static bool Insertar(PerfilUsuarioEntity perfilUsuario)
        {
            /* Verifico que no se repita el nombre */
            SqlDataReader lector = null;
            bool verificacion = false;
            try
            {
                List<SqlParameter> parametrosVerificacion = new List<SqlParameter>();
                parametrosVerificacion.Add(new SqlParameter("@usuario", perfilUsuario.Usuario));
                lector = SqlServer.ExecuteQuery("SELECT id FROM perfiles_usuario WHERE usuario=@usuario", parametrosVerificacion);
                verificacion = lector.HasRows;
            }
            catch (Exception e)
            {
                throw new ClassException("Error al verificar unicidad del nombre de usuario", "PerfilUsuario", "Insertar", e);
            }
            finally
            {
                if (lector != null && !lector.IsClosed)
                {
                    lector.Close();
                }
            }

            /* Inserto */
            try
            {
                if (!verificacion)
                {
                    List<SqlParameter> parametros = new List<SqlParameter>();
                    parametros.Add(new SqlParameter("@usuario", perfilUsuario.Usuario));
                    parametros.Add(new SqlParameter("@contrasenia", perfilUsuario.Contrasenia));
                    parametros.Add(new SqlParameter("@altura", perfilUsuario.Altura));
                    parametros.Add(new SqlParameter("@complexion", perfilUsuario.Complexion));
                    parametros.Add(new SqlParameter("@dieta", perfilUsuario.Dieta));
                    parametros.Add(new SqlParameter("@fecha_nacimiento", perfilUsuario.FechaNacimiento));
                    parametros.Add(new SqlParameter("@medida_cadera", perfilUsuario.MedidaCadera));
                    parametros.Add(new SqlParameter("@medida_cintura", perfilUsuario.MedidaCintura));
                    parametros.Add(new SqlParameter("@medida_torax", perfilUsuario.MedidaTorax));
                    parametros.Add(new SqlParameter("@peso", perfilUsuario.Peso));
                    parametros.Add(new SqlParameter("@rutina", perfilUsuario.Rutina));
                    parametros.Add(new SqlParameter("@sexo", perfilUsuario.Sexo));

                    SqlServer.ExecuteNonQuery("INSERT INTO bancos (usuario, contrasenia, altura, complexion, dieta, fecha_nacimiento, medida_cadera, medida_cintura, medida_torax, peso, rutina, sexo) VALUES (@usuario, @contrasenia, @altura, @complexion, @dieta, @fecha_nacimiento, @medida_cadera, @medida_cintura, @medida_torax, @peso, @rutina, @sexo)", parametros);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new ClassException("No se pudo insertar el perfil de usuario", "PerfilUsuario", "Insertar", e);
            }
        }
    }
}