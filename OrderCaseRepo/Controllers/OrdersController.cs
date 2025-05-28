using Microsoft.AspNetCore.Mvc;
using OrderCaseRepo.Business.Dtos.Orders;
using OrderCaseRepo.Business.Services.Interfaces;

namespace OrderCaseRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrders(int userId)
        {
            var response = await orderService.GetOrders(userId);
            return Ok(response);
        }

        [HttpGet("order_id/{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var response = await orderService.GetOrderById(orderId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDto order)
        {
            var response = await orderService.CreateOrder(order);
            return response ? NoContent() : StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> RemoveOrder(int orderId)
        {
            var response = await orderService.RemoveOrder(orderId);
            return response ? NoContent() : StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
