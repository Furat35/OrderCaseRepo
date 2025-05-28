using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Business.Dtos.Orders;
using OrderCaseRepo.Business.Services.Interfaces;
using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories;
using OrderCaseRepo.Data.Repositories.Contexts;

namespace OrderCaseRepo.Business.Services
{
    public class OrderService(OrderDbContext dbContext, ICatalogService catalogService, IMapper mapper) : OrderRepository(dbContext), IOrderService
    {
        public async Task<List<OrderListDto>> GetOrders(int userId)
        {
            var orders = await (await GetAll(_ => _.UserId == userId, includes: [_ => _.Address]))
                .Include(_ => _.OrderItems)
                .ThenInclude(_ => _.Catalog)
                .ToListAsync();
            return mapper.Map<List<OrderListDto>>(orders);
        }

        public async Task<OrderListDto> GetOrderById(int userId)
        {
            var order = await (await GetAll(o => o.UserId == userId, includes: [_ => _.Address]))
                .Include(_ => _.OrderItems)
                .ThenInclude(_ => _.Catalog)
                .FirstOrDefaultAsync();
            if (order is null)
                throw new ArgumentNullException(nameof(order));

            return mapper.Map<OrderListDto>(order);

        }

        public async Task<bool> CreateOrder(OrderCreateDto orderModel)
        {
            foreach (var orderItem in orderModel.OrderItems)
            {
                var catalog = await catalogService.GetByIdAsync(orderItem.CatalogId);
                if (orderItem.Quantity > catalog.AvailableStock)
                    throw new Exception($"Not enough stock for {orderItem.CatalogId}");
            }
            var order = mapper.Map<Order>(orderModel);
            await AddAsync(order);

            return await SaveChangesAsync() > 0;
        }


        public async Task<bool> RemoveOrder(int orderId)
        {
            var order = await GetByIdAsync(orderId);
            if (!order.IsValid) return true;
                
            order.IsValid = false;
            return await SaveChangesAsync() > 0;
        }
    }
}
