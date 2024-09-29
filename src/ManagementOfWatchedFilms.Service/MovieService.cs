using FluentValidation;
using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Domain.Interface.Service;
using ManagementOfWatchedFilms.Infrastructure.Core.Entity.Exceptions;
using ManagementOfWatchedFilms.Infrastructure.Core.Extensions;
using ManagementOfWatchedFilms.Service.Validator;

namespace ManagementOfWatchedFilms.Service
{
    public class MovieService : ServiceBase<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task AddAsync(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(UniversalErrorCode.U001.Code);

            SetDefaultNewEntityProperties(movie);

            var validator = new MovieValidator();
            await validator.ValidateAndThrowAsync(movie);

            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            if (id.IsEmpty())
                throw new ArgumentNullException(UniversalErrorCode.U002.Code);

            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
                throw new ArgumentNullException(MovieErrorCode.M001.Code);

            _movieRepository.Remove(movie);
            await _movieRepository.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllAsync() =>
            await _movieRepository.GetAllAsync();

        public async Task<List<Movie>> GetAllMoviesWatchedAsync() =>
            await _movieRepository.FindAsync(x => x.Watched != null && x.Watched.Value);

        public async Task UpdateByIdAsync(Guid id, Movie movie)
        {
            if (id.IsEmpty())
                throw new ArgumentNullException(UniversalErrorCode.U002.Code);

            var entity = await _movieRepository.GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentNullException(MovieErrorCode.M001.Code);

            entity.Description = movie.Description;
            entity.IMDbId = movie.IMDbId;
            entity.Name = movie.Name;
            entity.ReleaseDate = movie.ReleaseDate;
            entity.Genre = movie.Genre;
            entity.Watched = movie.Watched;
            entity.UserScore = movie.UserScore;

            _movieRepository.Update(entity);
            await _movieRepository.SaveChangesAsync();
        }
    }
}