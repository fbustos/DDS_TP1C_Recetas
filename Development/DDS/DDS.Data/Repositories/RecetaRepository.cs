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
    }
}
