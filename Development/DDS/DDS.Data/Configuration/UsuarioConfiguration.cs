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
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuarios").HasKey(u => u.Id);
            Property(u => u.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Username).IsRequired().HasMaxLength(50);
            Property(u => u.Password).IsRequired().HasMaxLength(50);
            Property(u => u.FechaCreacion).IsRequired();
            Property(u => u.FechaUltimaModificacion).IsOptional();
            Property(u => u.Perfil.Altura).IsOptional();
            Property(u => u.Perfil.Complexion).IsOptional();
            Property(u => u.Perfil.Dieta).IsOptional();
            Property(u => u.Perfil.Rutina).IsOptional();
            Property(u => u.Perfil.Nombre).IsOptional().HasMaxLength(50);
            Property(u => u.Perfil.Sexo).IsOptional();
            Property(u => u.Perfil.PreferenciaAlimenticia).IsOptional();
            Property(u => u.Perfil.FechaNacimiento).IsOptional();

            HasMany(c => c.UsuarioRecetas)
               .WithRequired(x => x.Usuario)
               .Map(cp => cp.MapKey("UsuarioId"));

            HasMany(x => x.Consultas)
                .WithRequired(x => x.Usuario)
                .Map(p => p.MapKey("UsuarioId"));

            HasMany(x => x.Planificaciones)
                .WithRequired(x => x.Usuario)
                .Map(p => p.MapKey("UsuarioId"));
        }
    }
}
