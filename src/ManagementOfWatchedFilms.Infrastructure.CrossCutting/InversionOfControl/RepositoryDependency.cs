using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementOfWatchedFilms.Infrastructure.CrossCutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}