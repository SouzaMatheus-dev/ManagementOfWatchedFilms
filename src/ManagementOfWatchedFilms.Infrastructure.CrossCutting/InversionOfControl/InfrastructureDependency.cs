using ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementOfWatchedFilms.Infrastructure.CrossCutting.InversionOfControl
{
    public static class InfrastructureDependency
    {
        public static void AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIMDbDependency(configuration);
        }
    }
}