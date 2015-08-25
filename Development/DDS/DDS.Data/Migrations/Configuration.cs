using System.Collections.Generic;
using DDS.Model.Models;

namespace DDS.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DDS.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DDS.Data.DataContext context)
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
                    FechaCreacion = DateTime.Now,
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
