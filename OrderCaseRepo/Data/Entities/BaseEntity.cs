namespace OrderCaseRepo.Data.Entities
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
    }
}
