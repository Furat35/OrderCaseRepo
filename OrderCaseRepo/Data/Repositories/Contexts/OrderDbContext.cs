using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Data.Entities;

namespace OrderCaseRepo.Data.Repositories.Contexts
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
