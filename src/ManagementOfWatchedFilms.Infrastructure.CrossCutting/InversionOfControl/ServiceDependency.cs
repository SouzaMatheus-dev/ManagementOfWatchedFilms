using ManagementOfWatchedFilms.Domain.Interface.Service;
using ManagementOfWatchedFilms.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementOfWatchedFilms.Infrastructure.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}