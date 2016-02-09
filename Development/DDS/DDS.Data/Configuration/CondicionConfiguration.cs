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
    public class CondicionConfiguration : EntityTypeConfiguration<Condicion>
    {
        public CondicionConfiguration()
        {
            ToTable("Condiciones").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsOptional();

            HasMany(x => x.Usuarios).WithOptional(x => x.Condicion)
                .Map(p => p.MapKey("CondicionId"));

            HasMany(x => x.Recetas).WithOptional(x => x.Condicion)
                .Map(p => p.MapKey("CondicionId"));
        }
    }
}
