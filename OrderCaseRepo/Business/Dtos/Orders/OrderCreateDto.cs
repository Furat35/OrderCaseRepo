using OrderCaseRepo.Business.Dtos.Addresses;
using OrderCaseRepo.Business.Dtos.OrderItems;

namespace OrderCaseRepo.Business.Dtos.Orders
{
    public class OrderCreateDto
    {
        public string Description { get; set; }
        public ICollection<OrderItemCreateDto> OrderItems { get; set; }
        public AddressCreateDto Address { get; set; }
        public int UserId { get; set; }
    }
}
