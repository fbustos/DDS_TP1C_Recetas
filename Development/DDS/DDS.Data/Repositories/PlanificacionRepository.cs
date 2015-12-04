using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class PlanificacionRepository : RepositoryBase<Planificacion>, IPlanificacionRepository
    {
        public PlanificacionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
