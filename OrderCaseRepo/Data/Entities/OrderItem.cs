namespace OrderCaseRepo.Data.Entities
{
    public class OrderItem : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
    }
}
