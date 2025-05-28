using OrderCaseRepo.Data.Entities;
using System.Linq.Expressions;

namespace OrderCaseRepo.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IQueryable<TEntity> GetAll(bool isTracking = false);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(int id, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<bool> Exists(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
