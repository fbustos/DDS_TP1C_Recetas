using System.ComponentModel.DataAnnotations.Schema;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Data.Configuration
{
    public class RecetaConfiguration : EntityTypeConfiguration<Receta>
    {
        public RecetaConfiguration()
        {
            ToTable("Recetas").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsOptional();
            Property(u => u.Dificultad).IsOptional();
            Property(u => u.Temporada).IsOptional();
            Property(u => u.Calorias).IsOptional();
            Property(u => u.Desayuno).IsRequired();
            Property(u => u.Almuerzo).IsRequired();
            Property(u => u.Merienda).IsRequired();
            Property(u => u.Cena).IsRequired();
            Property(u => u.FechaCreacion).IsRequired();
            Property(u => u.FechaUltimaModificacion).IsOptional();
            Property(u => u.TotalVotos).IsOptional();
            Property(u => u.CantidadVotos).IsOptional();

            HasMany(x => x.Ingredientes).WithMany(x => x.Recetas).Map(
                m =>
                {
                    m.MapLeftKey("RecetaId");
                    m.MapRightKey("IngredienteId");
                    m.ToTable("RecetasIngredientes");
                });

            HasMany(x => x.Condimentos).WithMany(x => x.Recetas).Map(
                m =>
                {
                    m.MapLeftKey("RecetaId");
                    m.MapRightKey("CondimentoId");
                    m.ToTable("RecetasCondimentos");
                });

            HasMany(x => x.Pasos).WithRequired(x => x.Receta)
                .Map(p => p.MapKey("RecetaId"));

            HasRequired(x => x.CreadaPor)
                .WithMany()
                .Map(p => p.MapKey("UsuarioId"));

            HasMany(c => c.UsuarioRecetas)
               .WithRequired(x => x.Receta)
               .Map(cp => cp.MapKey("RecetaId"))
               .WillCascadeOnDelete(false);
        }
    }
}
