using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static MovieStore.Application.ActorOperations.Quaries.GetActor.GetActorQuery;
using static MovieStore.Application.ActorOperations.Quaries.GetActor.GetActorsDetailsQuery;
using static MovieStore.Application.ActorOperations.Quaries.GetFalseActor.GetFalseActorQuery;
using static MovieStore.Application.CustomerOperations.CreateCustomer.CreateCustomerCommand;
using static MovieStore.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static MovieStore.Application.DirectorOperations.Quaries.GetDirector.GetDirectorQuery;
using static MovieStore.Application.DirectorOperations.Quaries.GetDirectorDetails.GetDirectorDetailsQuery;
using static MovieStore.Application.DirectorOperations.Quaries.GetFalseDirectors.GetFalseDirectorQuery;
using static MovieStore.Application.MovieOperations.Commands.CreateMovie.CreateMoviesQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetFalseMovies.GetFalseMoviesQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetMovies.GetMoveisQuery;
using static MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails.GetMoviesDetailsQuery;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //  Movie
                //  MovieCreate
            CreateMap<CreateMoviesModel, Movie>();
                //  MovieGet
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));
                //  MovieGetDetail
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));        
            CreateMap<Actor, ActorNameViewModel>();
            CreateMap<Director, DirectorNameViewModel>();
            //  Delete(IsActive : false) Movie
            CreateMap<Movie, GetFalseMoviesViewModel>()
                .ForMember(dest => dest.MovieGenre, opt => opt.MapFrom(src => $"{src.MovieGenre.GenreName}"));


            //  Actor
                //  ActorGet
            CreateMap<Actor, GetActorViewModel>();
                //  ActorGetDetails
            CreateMap<Actor, GetActorDetailsViewModel>();
            CreateMap<Movie, ActorMovieViewModel>();
                //  ActorCreate
            CreateMap<CreateActorModel, Actor>();
            //  Delete(IsActive : False) Actor
            CreateMap<Actor, GetFalseActorViewModel>();
            CreateMap<Movie, FalseActorMovieViewModel>();


            //  Director
                //  DirectorGet
            CreateMap<Director, GetDirectorViewModel>();
                //  DirectorGetDetail
            CreateMap<Director, GetDirectorDetailsViewModel>();
            CreateMap<Movie, MovieNameViewModel>();
                //  DirectorCreate
            CreateMap<CreateDirectorModel, Director>();
            //  Delete(IsActive : False) Director
            CreateMap<Director, GetFalseDirectorViewModel>();
            CreateMap<Movie, FalseMovieNameViewModel>();


            //  Customer
            CreateMap<CreateCustomerModel, Customer>();
        }   
    }
}
