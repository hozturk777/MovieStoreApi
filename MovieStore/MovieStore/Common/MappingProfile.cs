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
        private readonly IMovieContext _movieContext;
        public MappingProfile()
        {
            //  Movie
            CreateMap<CreateMoviesModel, Movie>();
            

            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));
            //CreateMap<Movie, MovieDetailsViewModel>()
            //.ForMember(dest => dest.MovieActor, opt => opt.MapFrom(src => $"{src.MovieActor.ActorName}"));
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));
            //.ForMember(dest => dest.MovieActor, opt => opt.MapFrom(src => returnActors(src.MovieActorId)));

            CreateMap<Actor, MovieActorViewModel>();



            //  Actor
            CreateMap<Actor, GetActorViewModel>()
                .ForMember(dest => dest.IdId, opt => opt.MapFrom(src => src.Id.ToString()));
            //.ForMember(dest => dest.ActorMovie, opt => opt.MapFrom(src => $"{src.ActorMovie.}"));
            CreateMap<CreateActorModel, Actor>();

        }
        public List<Actor>? returnActors(int? actors)
        {
         
           // var falan = _context.Actors.OrderBy(x => x.Id);
            List<Actor> de = new List<Actor>();
            //foreach (var  in actors)
            //{

            //}

            //List<Actor> dene = den.IndexOf();

            //foreach (var actor in actors)
            //{
            //    var f = ;
            //    //den.Add(_context.Actors.Select(x => x.Id = y));
            //}

            //var fa = context.Actors.Where(x => x.den == actors.ToString());
            //de.AddRange(fa);
            return de;
        }
    }
}
