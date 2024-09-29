using System.Linq.Expressions;

namespace ManagementOfWatchedFilms.Domain.Interface.Repository
{
    public interface IRepository<T> where T : Entity.IEntity
    {
        void Add(T entity);

        Task AddAsync(T entity);

        void AddRange(List<T> entities);

        Task AddRangeAsync(List<T> entities);

        List<T> Find(Expression<Func<T, bool>> expression, int queryContext = default);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> expression, int queryContext = default);

        T GetById(Guid id, int queryContext = default);

        Task<T> GetByIdAsync(Guid id, int queryContext = default);

        List<T> GetAll(int queryContext = default);

        Task<List<T>> GetAllAsync(int queryContext = default);

        void Remove(T entity);

        void RemoveRange(List<T> entities);

        void Update(T entity);

        void UpdateRange(List<T> entities);

        void SaveChanges();

        Task SaveChangesAsync();

        IQueryable<T> Query(int queryContext = default);
    }
}