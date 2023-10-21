using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails
{
    public class GetMoviesDetailsQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;
        public GetMoviesDetailsQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovieDetailsViewModel> Handle()
        {
            var movieList = _context.Movies
                .Where(x => x.IsActive == true)
                .Include(x => x.MovieActor)
                .Include(x => x.MovieGenre)
                .OrderBy(x => x.Id)
                .ToList();
            List<MovieDetailsViewModel> movieDetails = _mapper.Map<List<MovieDetailsViewModel>>(movieList);
            return movieDetails;
        }

        public class MovieDetailsViewModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public string? MovieGenre { get; set; }
            public string? MovieDirector { get; set; }
            public List<Actor>? MovieActor { get; set; }
            public string? PublishDate { get; set; }

        }
    }
}
