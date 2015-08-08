using DDS.Data.Configuration;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("RecetasConnection")
        { }

        public DbSet<Usuario> Usuarios { get; set; }
 
        public virtual void Commit()
        {
            base.SaveChanges();
        }
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
        }
    }
}
