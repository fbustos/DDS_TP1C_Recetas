using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
