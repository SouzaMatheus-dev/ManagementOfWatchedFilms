namespace ManagementOfWatchedFilms.Domain.Interface.Service
{
    public interface IService<T>
    {
        void SetDefaultNewEntityProperties(T entity);
    }

    public interface IService
    {
    }
}