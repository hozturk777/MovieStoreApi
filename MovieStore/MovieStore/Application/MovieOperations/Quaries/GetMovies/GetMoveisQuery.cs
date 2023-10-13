using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;

namespace MovieStore.Application.MovieOperations.Quaries.GetMovies
{
    public class GetMoveisQuery
    {
        private readonly IMovieContext _movieContext;
        private readonly IMapper _mapper;

        public GetMoveisQuery(IMovieContext movieContext, IMapper mapper)
        {
            _movieContext = movieContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _movieContext.Movies.Include(x => x.MovieActor).Include(x => x.MovieDirector).Include(x => x.MovieGenre).OrderBy(x => x.Id).ToList();
            List<MovieViewModel> movieViewModels = _mapper.Map<List<MovieViewModel>>(movieList);
            return movieViewModels;
        }

        public class MovieViewModel
        {
            public string? MovieName { get; set; }
            public int Price { get; set; }
            public string? MovieGenre { get; set; }
            public string? MovieDirector { get; set; }
            public string? MovieActor { get; set; }
            public int PublishDate { get; set; }
        }

    }
}
