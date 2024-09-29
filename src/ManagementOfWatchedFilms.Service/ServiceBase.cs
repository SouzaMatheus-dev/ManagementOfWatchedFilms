using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Domain.Interface.Service;

namespace ManagementOfWatchedFilms.Service
{
    public class ServiceBase<T> : IService<T> where T : IEntity
    {
        public void SetDefaultNewEntityProperties(T entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();
        }
    }
}