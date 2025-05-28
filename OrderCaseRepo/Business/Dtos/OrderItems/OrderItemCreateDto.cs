namespace OrderCaseRepo.Business.Dtos.OrderItems
{
    public class OrderItemCreateDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CatalogId { get; set; }
    }
}
