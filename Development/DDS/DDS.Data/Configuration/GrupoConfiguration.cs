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
    public class GrupoConfiguration : EntityTypeConfiguration<Grupo>
    {
        public GrupoConfiguration()
        {
            ToTable("Grupos").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsOptional().HasMaxLength(50);
            Property(u => u.Descripcion).IsOptional().IsMaxLength();
            Property(u => u.CreadoPor).IsRequired();
            Property(u => u.FechaCreacion).IsRequired();
            Property(u => u.FechaModificacion).IsOptional();
            
            HasMany(x => x.Usuarios).WithMany(x => x.Grupos).Map(
               m =>
               {
                   m.MapLeftKey("GrupoId");
                   m.MapRightKey("UsuarioId");
                   m.ToTable("GruposUsuarios");
                   
               });
        }
    }
}
