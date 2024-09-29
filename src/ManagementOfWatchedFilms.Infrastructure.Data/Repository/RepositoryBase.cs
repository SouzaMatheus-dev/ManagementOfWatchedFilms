using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ManagementOfWatchedFilms.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly EntityContext _entityContext;

        public RepositoryBase(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void Add(TEntity entity)
        {
            _entityContext.Set<TEntity>().Add(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            return _entityContext.Set<TEntity>().AddAsync(entity).AsTask();
        }

        public void AddRange(List<TEntity> entities)
        {
            _entityContext.Set<TEntity>().AddRange(entities);
        }

        public Task AddRangeAsync(List<TEntity> entities)
        {
            return _entityContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> expression, int queryContext = default)
        {
            return _entityContext.Set<TEntity>().Where(expression).ToList();
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, int queryContext = default)
        {
            return _entityContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public List<TEntity> GetAll(int queryContext = default)
        {
            return _entityContext.Set<TEntity>().ToList();
        }

        public Task<List<TEntity>> GetAllAsync(int queryContext = default)
        {
            return _entityContext.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(Guid id, int queryContext = default)
        {
            return _entityContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public Task<TEntity> GetByIdAsync(Guid id, int queryContext = default)
        {
            return _entityContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(TEntity entity)
        {
            _entityContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _entityContext.Set<TEntity>().RemoveRange(entities);
        }

        public void SaveChanges()
        {
            _entityContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _entityContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _entityContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _entityContext.Set<TEntity>().UpdateRange(entities);
        }

        public virtual IQueryable<TEntity> Query(int queryContext = default)
        {
            return _entityContext.Set<TEntity>();
        }
    }
}