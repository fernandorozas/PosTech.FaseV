using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Domain;

namespace PosTech.FaseV.SqlServer.Repositories
{
    public class RepositoryAsset : Repository<Asset>, IRepositoryAsset
    {
        public RepositoryAsset(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
