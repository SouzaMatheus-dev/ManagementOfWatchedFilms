namespace ManagementOfWatchedFilms.Domain.Interface.Repository
{
    public interface IUnitOfWork
    {
        void Commit();

        Task CommitAsync();

        void Rollback();

        Task RollbackAsync();
    }
}