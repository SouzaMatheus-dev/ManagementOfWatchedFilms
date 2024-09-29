using AutoMapper;
using ManagementOfWatchedFilms.API.Models.Movie;
using ManagementOfWatchedFilms.Domain.Entity;

namespace ManagementOfWatchedFilms.API.Infrastructure.AutoMapper.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieRequest, Movie>()
                .ReverseMap();

            CreateMap<MovieResponse, Movie>()
                .ReverseMap();
        }
    }
}