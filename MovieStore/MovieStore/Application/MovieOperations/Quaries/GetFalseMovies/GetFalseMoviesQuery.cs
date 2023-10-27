using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using static MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails.GetMoviesDetailsQuery;

namespace MovieStore.Application.MovieOperations.Quaries.GetFalseMovies
{
    public class GetFalseMoviesQuery
    {
        private readonly IMovieContext _context;
        private readonly IMapper _mapper;

        public GetFalseMoviesQuery(IMovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetFalseMoviesViewModel> Handle()
        {
            var movieList = _context.Movies
                .Where(x => x.IsActive == false)
                .Include(x => x.MovieActor)
                .Include(x => x.MovieDirector)
                .Include(x => x.MovieGenre)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetFalseMoviesViewModel> movieDetails = _mapper.Map<List<GetFalseMoviesViewModel>>(movieList);
            return movieDetails;
        }

        public class GetFalseMoviesViewModel
        {
            public int? Id { get; set; }
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public string? MovieGenre { get; set; }
            public ICollection<DirectorNameViewModel>? MovieDirector { get; set; }
            public ICollection<ActorNameViewModel>? MovieActor { get; set; }
            public string? PublishDate { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
