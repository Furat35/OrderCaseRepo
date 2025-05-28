namespace OrderCaseRepo.Data.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public Guid PasswordSalt { get; set; }
        public string HashedPassword { get; set; }
    }
}
