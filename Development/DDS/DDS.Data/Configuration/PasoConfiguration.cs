using System.ComponentModel.DataAnnotations.Schema;
using DDS.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace DDS.Data.Configuration
{
    public class PasoConfiguration : EntityTypeConfiguration<Paso>
    {
        public PasoConfiguration()
        {
            ToTable("Pasos").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Numero).IsRequired();
            Property(u => u.Descripcion).IsOptional().IsMaxLength();
            Property(u => u.ImagenPath).IsOptional();
        }
    }
}
