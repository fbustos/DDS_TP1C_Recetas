using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class PasoRepository : RepositoryBase<Paso>, IPasoRepository
    {
        public PasoRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
