﻿using System.ComponentModel.DataAnnotations.Schema;
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
            Property(u => u.Dificultad).IsOptional();
            Property(u => u.Nombre).IsOptional();
            Property(u => u.Calorias).IsOptional();

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
            HasMany(x => x.Pasos).WithMany(x => x.Recetas).Map(
                m =>
                {
                    m.MapLeftKey("RecetaId");
                    m.MapRightKey("PasoId");
                    m.ToTable("RecetasPasos");
                });
        }
    }
}
