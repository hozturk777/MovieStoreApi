using AutoMapper;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movie
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.MovieGenre.GenreName));
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieActor, opt => opt.MapFrom(src => src.MovieActor.ActorName));
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieDirector, opt => opt.MapFrom(src => src.MovieDirector.DirectorName));
        }
    }
}
