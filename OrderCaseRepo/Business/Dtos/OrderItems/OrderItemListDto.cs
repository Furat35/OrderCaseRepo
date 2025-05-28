using OrderCaseRepo.Business.Dtos.Catalogs;

namespace OrderCaseRepo.Business.Dtos.OrderItems
{
    public class OrderItemListDto
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public CatalogListDto Catalog { get; set; }
        public bool IsValid { get; set; }
    }
}
