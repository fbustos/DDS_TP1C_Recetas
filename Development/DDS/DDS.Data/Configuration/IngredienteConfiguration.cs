using System.ComponentModel.DataAnnotations.Schema;
using DDS.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace DDS.Data.Configuration
{
    public class IngredienteConfiguration : EntityTypeConfiguration<Ingrediente>
    {
        public IngredienteConfiguration()
        {
            ToTable("Ingredientes").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsOptional();
            Property(u => u.Porcion).IsOptional();
            Property(u => u.CaloriasPorcion).IsOptional();
        }
    }
}
