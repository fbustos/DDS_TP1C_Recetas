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
    public class CondimentoConfiguration : EntityTypeConfiguration<Condimento>
    {
        public CondimentoConfiguration()
        {
            ToTable("Condimentos").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsRequired();
            Property(u => u.Tipo).IsRequired();
        }
    }
}
