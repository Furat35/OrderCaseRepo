using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Contexts;
using OrderCaseRepo.Data.Repositories.Interfaces;

namespace OrderCaseRepo.Data.Repositories
{
    public class OrderRepository(OrderDbContext dbContext) : BaseRepository<OrderDbContext, Order>(dbContext)
    {
    }
}
