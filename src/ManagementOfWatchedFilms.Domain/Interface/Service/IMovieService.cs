using ManagementOfWatchedFilms.Domain.Entity;

namespace ManagementOfWatchedFilms.Domain.Interface.Service
{
    public interface IMovieService : IService
    {
        Task AddAsync(Movie movie);

        Task DeleteByIdAsync(Guid id);

        Task<List<Movie>> GetAllAsync();

        Task<List<Movie>> GetAllMoviesWatchedAsync();

        Task UpdateByIdAsync(Guid id, Movie movie);
    }
}