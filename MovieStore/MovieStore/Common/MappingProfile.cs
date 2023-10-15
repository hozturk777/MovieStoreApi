using AutoMapper;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails.GetMoviesDetailsQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Movie
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => src.MovieGenre.GenreName));
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.MovieActor, opt => opt.MapFrom(src => returnActors(src.MovieActor)));
        }
        public List<string> returnActors(List<Actor> actors)
        {
            List<string> actorNames = new List<string>();
            foreach (Actor actor in actors)
            {
                actorNames.Add(actor.ActorName + " " + actor.ActorSurname);
            }
            return actorNames;
        }
    }
}
