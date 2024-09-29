using FluentValidation;
using ManagementOfWatchedFilms.Domain.Entity;

namespace ManagementOfWatchedFilms.Service.Validator
{
    public class EntityValidator<T> : AbstractValidator<T> where T : IEntity
    {
        protected EntityValidator()
        {
        }
    }
}