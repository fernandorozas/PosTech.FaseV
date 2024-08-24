using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.SqlServer.Repositories
{
    public class RepositoryTransaction : Repository<Transaction>, IRepositoryTransaction
    {
        public RepositoryTransaction(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
