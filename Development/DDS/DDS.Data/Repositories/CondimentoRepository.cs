using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class CondimentoRepository : RepositoryBase<Condimento>, ICondimentoRepository
    {
        public CondimentoRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
