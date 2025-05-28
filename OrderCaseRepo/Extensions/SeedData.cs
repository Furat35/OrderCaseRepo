using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Data.Repositories.Contexts;

namespace OrderCaseRepo.Extensions
{
    public static class SeedData
    {
        public static void SeedDb(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<OrderDbContext>();
                dbContext.Database.Migrate();
                if (!dbContext.Users.Any())
                {
                    dbContext.Users.Add(new()
                    {
                        CreateDate = DateTime.Now,
                        Email = "firat@gmail.com",
                        Fullname = "firat ortac",
                        HashedPassword = Guid.NewGuid().ToString(),
                        PasswordSalt = Guid.NewGuid().ToString(),
                        Username = "firat35"
                    });
                }
                if (!dbContext.Catalogs.Any())
                {
                    dbContext.Catalogs.Add(new()
                    {
                        AvailableStock = 99,
                        CatalogBrand = "İphone",
                        CatalogType = "Electronic",
                        CreateDate = DateTime.Now,
                        Description = "iphone 15 ....",
                        Name = "İphone 15",
                        PictureUrl = "fdsfdasfdasfd",
                        Price = 324
                    });
                }


                dbContext.SaveChanges();
            }

        }
    }
}
