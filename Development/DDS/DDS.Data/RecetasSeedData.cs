using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDS.Model.Models;

namespace DDS.Data
{
    public class RecetasSeedData : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            GetUsuarios().ForEach(u => context.Usuarios.Add(u));
            GetIngredientes().ForEach(u => context.Ingredientes.Add(u));
            GetCondimentos().ForEach(u => context.Condimentos.Add(u));

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

        private static List<Ingrediente> GetIngredientes()
        {
            var ingredientes = new List<Ingrediente>
            {
                new Ingrediente {
                    Id = 1,
                    Nombre = "Huevo",
                    CaloriasPorcion = 200,
                    Porcion = 1
                },
                new Ingrediente
                {
                    Id = 2,
                    Nombre = "Leche",
                    CaloriasPorcion = 150,
                    Porcion = 1
                },
                new Ingrediente
                {
                    Id = 3,
                    Nombre = "Crema",
                    CaloriasPorcion = 200,
                    Porcion = 2
                }
            };
            return ingredientes;
        }

        private static List<Condimento> GetCondimentos()
        {
            var condimentos = new List<Condimento>
            {
                new Condimento {
                    Id = 1,
                    Nombre = "Sal",
                    Tipo = "Especias"
                },
                new Condimento
                {
                    Id = 2,
                    Nombre = "Aceite Maiz",
                    Tipo = "Liquidos"
                },
                new Condimento
                {
                    Id = 3,
                    Nombre = "Pimienta",
                    Tipo = "Especias"
                }
            };
            return condimentos;
        }
    }
}
