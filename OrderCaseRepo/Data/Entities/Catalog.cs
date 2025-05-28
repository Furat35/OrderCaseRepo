namespace OrderCaseRepo.Data.Entities
{
    public class Catalog : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int AvailableStock { get; set; }
        public string CatalogType{ get; set; }
        public string CatalogBrand{ get; set; }
    }
}
