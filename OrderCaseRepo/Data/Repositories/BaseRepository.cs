using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace OrderCaseRepo.Data.Repositories
{
    public class BaseRepository<TContext, TEntity>(TContext dbContext) : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity, new()
    {
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public virtual async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (!isTracking)
                query = query.AsNoTracking();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (!isTracking)
                query = query.AsNoTracking();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public virtual int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.Set<TEntity>().AnyAsync(_ => _.Id == id);
        }
    }
}

