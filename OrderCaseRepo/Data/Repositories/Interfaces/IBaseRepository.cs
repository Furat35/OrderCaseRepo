using OrderCaseRepo.Data.Entities;
using System.Linq.Expressions;

namespace OrderCaseRepo.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(int id, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> ExistsAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task DeleteByIdAsync(int id);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
