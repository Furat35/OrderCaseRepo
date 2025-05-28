namespace OrderCaseRepo.Data.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
