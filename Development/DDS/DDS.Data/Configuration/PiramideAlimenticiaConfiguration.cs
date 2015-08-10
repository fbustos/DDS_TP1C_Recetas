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
    public class PiramideAlimenticiaConfiguration : EntityTypeConfiguration<PiramideAlimenticia>
    {
        public PiramideAlimenticiaConfiguration()
        {
            ToTable("PiramideAlimenticias").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Nombre).IsRequired().HasMaxLength(50);
            Property(u => u.Descripcion).IsOptional().HasMaxLength(250);
            Property(u => u.Contraindicaciones).IsOptional().HasMaxLength(250);
        }
    }
}
