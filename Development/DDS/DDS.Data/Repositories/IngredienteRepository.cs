using DDS.Data.Infrastructure;
using DDS.Data.Interfaces;
using DDS.Model.Models;

namespace DDS.Data.Repositories
{
    public class IngredienteRepository : RepositoryBase<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }
}
