namespace OrderCaseRepo.Data.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsValid { get; set; } = true;
    }
}
