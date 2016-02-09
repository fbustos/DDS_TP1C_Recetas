using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDS.Model.Enums;
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
            GetCondiciones().ForEach(u => context.Condiciones.Add(u));

            context.Commit();
            GetRecetas(context).ForEach(u => context.Recetas.Add(u));
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

        private static List<Receta> GetRecetas(DataContext context)
        {
            var recetas = new List<Receta>
            {
                new Receta
                {
                    Nombre = "Receta de Verano",
                    Dificultad = Dificultad.Media,
                    Temporada = Temporada.Verano,
                    Merienda = true,
                    Desayuno = true,
                    FechaCreacion = DateTime.Now,
                    CreadaPor = context.Usuarios.Find(1),
                    Calorias = 200,
                    Ingredientes = context.Ingredientes.ToList(),
                    Condimentos = context.Condimentos.ToList()
                },
                new Receta
                {
                    Nombre = "Receta de Invierno",
                    Dificultad = Dificultad.Dificil,
                    Temporada = Temporada.Invierno,
                    Cena = true,
                    Almuerzo = true,
                    FechaCreacion = DateTime.Now,
                    CreadaPor = context.Usuarios.Find(1),
                    Calorias = 400,
                    Ingredientes = context.Ingredientes.ToList(),
                    Condimentos = context.Condimentos.ToList()
                }
            };

            return recetas;
        }

        private static List<Condicion> GetCondiciones()
        {
            var condiciones = new List<Condicion>();
            var diabetes = new Diabetes()
            {
                Id = 1,
                Nombre = "Diabetes"
            };
            condiciones.Add(diabetes);

            var hipertension = new Hipertension()
            {
                Id = 2,
                Nombre = "Hipertensión"
            };
            condiciones.Add(hipertension);

            var celiasis = new Celiasis()
            {
                Id = 3,
                Nombre = "Celiasis"
            };
            condiciones.Add(celiasis);

            return condiciones;
        }
    }
}
