using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMoviesQuery
    {
        public CreateMoviesModel Model { get; set; }
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public CreateMoviesQuery(IMovieContext movieContext, IMapper mapper)
        {
            _context = movieContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var createMovie = _context.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);
            if (createMovie != null)
            {
                throw new InvalidOperationException("Bu Film Zaten Var!");
            }
            createMovie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(createMovie);
            _context.SaveChanges();
        }

        public class CreateMoviesModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public int? MovieGenreId { get; set; } 
            //public string? MovieDirector { get; set; }
            //public List<Actor>? MovieActor { get; set; }
            //public string? PublishDate { get; set; }
        }
    }
}
