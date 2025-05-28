using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Contexts;

namespace OrderCaseRepo.Data.Repositories
{
    public class CatalogRepository(OrderDbContext dbContext) : BaseRepository<OrderDbContext, Catalog>(dbContext)
    {
    }
}
