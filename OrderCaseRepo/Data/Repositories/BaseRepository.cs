using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Data.Entities;
using OrderCaseRepo.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace OrderCaseRepo.Data.Repositories
{
    public class BaseRepository<TContext, TEntity>(TContext dbContext) : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity :BaseEntity, new()
    {

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public virtual Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            return Get(filter, null, isTracking, includes);
        }

        public virtual async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool isTracking = false, params Expression<Func<TEntity, object>>[] includes)
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

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAll(bool isTracking = false)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            return dbContext.Set<TEntity>();
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

            return await query.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();
            if (!isTracking)
                query = query.AsNoTracking();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(expression).SingleOrDefaultAsync();

        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            dbContext.Set<TEntity>().Remove(entity);

            return true;
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

        public Task<bool> Exists(int id)
        {
            return dbContext.Set<TEntity>().AnyAsync(_ => _.Id.Equals(id));
        }
    }
}

