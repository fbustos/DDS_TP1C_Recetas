using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDS.Model.Models;

namespace DDS.Data
{
    public class RecetasSeedData : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            GetUsuarios().ForEach(u => context.Usuarios.Add(u));

            context.Commit();
        }

        private static List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new Usuario {
                    Id = 1,
                    Username = "fbustos",
                    Perfil = new Perfil
                    {
                         Nombre = "Franco"
                    }
                }
            };

            usuarios.ForEach(x => x.SetPassword("123456"));
            return usuarios;
        }
    }
}
