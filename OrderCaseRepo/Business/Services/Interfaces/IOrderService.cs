using OrderCaseRepo.Business.Dtos.Orders;
using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Interfaces;

namespace OrderCaseRepo.Business.Services.Interfaces
{
    public interface IOrderService : IBaseRepository<Order>
    {
        Task<List<OrderListDto>> GetOrders(int userId);
        Task<OrderListDto> GetOrderById(int userId);
        Task<bool> CreateOrder(OrderCreateDto orderModel);
        Task<bool> RemoveOrder(int orderId);

    }
}
