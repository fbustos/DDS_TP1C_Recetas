using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDS.Data.Repositories
{
    public class RecetaRepository : RepositoryBase<Receta>, IRecetaRepository
    {
        public RecetaRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Delete(Receta entity)
        {
            using (var dbContext = DbContext)
            {
                dbContext.Consultas.RemoveRange(entity.Consultas);
                dbContext.Planificaciones.RemoveRange(entity.Planificaciones);
                dbContext.UsuarioRecetas.RemoveRange(entity.UsuarioRecetas);
                dbContext.Recetas.Remove(entity);
                dbContext.Commit();
            }
        }
    }
}
