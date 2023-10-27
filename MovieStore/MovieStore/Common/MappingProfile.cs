using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static MovieStore.Application.ActorOperations.Quaries.GetActor.GetActorsQuery;
using static MovieStore.Application.MovieOperations.Commands.CreateMovie.CreateMoviesQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails.GetMoviesDetailsQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //  Movie
            CreateMap<CreateMoviesModel, Movie>();

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));

            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));
            
            CreateMap<Actor, ActorNameViewModel>();
            


            //  Actor
            CreateMap<Actor, GetActorViewModel>();  
            CreateMap<CreateActorModel, Actor>();

        }
        
        public List<string>? Actors(ICollection<Actor>? getActor)
        {
            List<string>? resultActor = new List<string>();
            foreach (var actor in getActor)
            {
                resultActor.Add(actor.ActorName + " " + actor.ActorSurname);
                
            }
            return resultActor;
        }
    }
}
