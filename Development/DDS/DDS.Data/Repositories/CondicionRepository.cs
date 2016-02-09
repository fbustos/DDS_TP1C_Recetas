using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class CondicionRepository : RepositoryBase<Condicion>, ICondicionRepository
    {
        public CondicionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
