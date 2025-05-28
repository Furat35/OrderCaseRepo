namespace OrderCaseRepo.Data.Entities
{
    public class Order : BaseEntity
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
