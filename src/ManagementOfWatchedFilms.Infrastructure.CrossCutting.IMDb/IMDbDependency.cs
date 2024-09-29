using ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb
{
    public static class IMDbDependency
    {
        public static void AddIMDbDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(nameof(IMDb), httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["IMDb:UrlBase"]!);
            });

            services.Configure<IMDbOptions>(options =>
            {
                configuration.GetSection("IMDb").Bind(options);
            });
            services.AddScoped<IMDb>();
        }
    }
}