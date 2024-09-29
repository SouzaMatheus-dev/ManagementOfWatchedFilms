using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Infrastructure.Data.Context;

namespace ManagementOfWatchedFilms.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _entityContext;

        public UnitOfWork(EntityContext entityContext) => _entityContext = entityContext;

        public void Commit()
        {
            _entityContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _entityContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _entityContext.Dispose();
        }

        public Task RollbackAsync()
        {
            return _entityContext.DisposeAsync().AsTask();
        }
    }
}