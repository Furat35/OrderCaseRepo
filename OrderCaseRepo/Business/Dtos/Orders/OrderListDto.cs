using OrderCaseRepo.Business.Dtos.Addresses;
using OrderCaseRepo.Business.Dtos.OrderItems;

namespace OrderCaseRepo.Business.Dtos.Orders
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<OrderItemListDto> OrderItems { get; set; }
        public AddressListDto Address { get; set; }
    }
}
