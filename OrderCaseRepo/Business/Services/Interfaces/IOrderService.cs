using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Interfaces;

namespace OrderCaseRepo.Business.Services.Interfaces
{
    public interface IOrderService : IBaseRepository<Order>
    {
    }
}
