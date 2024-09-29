using ManagementOfWatchedFilms.Domain.Entity;
using FluentValidation;

namespace ManagementOfWatchedFilms.Service.Validator
{
    public class MovieValidator : EntityValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.IMDbId).NotEmpty();
            RuleFor(x => x.Genre).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ReleaseDate).NotEmpty();
        }
    }
}