using DDS.Data.Configuration;
using DDS.Model.Models;
using System.Data.Entity;

namespace DDS.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("RecetasConnection")
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Condimento> Condimentos { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<UsuarioReceta> UsuarioRecetas { get; set; } 

        public virtual void Commit()
        {
            base.SaveChanges();
        }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new RecetaConfiguration());
            modelBuilder.Configurations.Add(new IngredienteConfiguration());
            modelBuilder.Configurations.Add(new CondimentoConfiguration());
            modelBuilder.Configurations.Add(new PasoConfiguration());
            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioRecetaConfiguration());
        }
    }
}
