using OrderCaseRepo.Business.Services.Interfaces;
using OrderCaseRepo.Data.Repositories;
using OrderCaseRepo.Data.Repositories.Contexts;

namespace OrderCaseRepo.Business.Services
{
    public class CatalogService(OrderDbContext dbContext) : CatalogRepository(dbContext), ICatalogService
    {
    }
}
