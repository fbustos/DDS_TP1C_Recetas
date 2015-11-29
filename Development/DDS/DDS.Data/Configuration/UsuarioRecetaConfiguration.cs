using System.ComponentModel.DataAnnotations.Schema;
using DDS.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace DDS.Data.Configuration
{
    public class UsuarioRecetaConfiguration : EntityTypeConfiguration<UsuarioReceta>
    {
        public UsuarioRecetaConfiguration()
        {
            ToTable("UsuarioRecetas").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Puntaje).IsOptional();
        }
    }
}
