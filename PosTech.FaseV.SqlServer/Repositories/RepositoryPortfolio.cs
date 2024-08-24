using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.SqlServer.Repositories
{
    public class RepositoryPortfolio : Repository<Portfolio>, IRepositoryPortfolio
    {
        public RepositoryPortfolio(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
