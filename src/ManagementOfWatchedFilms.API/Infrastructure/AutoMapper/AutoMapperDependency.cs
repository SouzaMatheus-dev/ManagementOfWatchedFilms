using AutoMapper;
using ManagementOfWatchedFilms.API.Infrastructure.AutoMapper.Profiles;

namespace ManagementOfWatchedFilms.API.Infrastructure.AutoMapper
{
    public static class AutoMapperDependency
    {
        public static void AddAutoMapperDependency(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc => //Add all AutoMapper profiles here
            {
                services.AddAutoMapperGeneralProfiles(mc);
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddAutoMapperGeneralProfiles(this IServiceCollection services, IMapperConfigurationExpression mc)
        {
            mc.AddProfile<MovieProfile>();
        }
    }
}