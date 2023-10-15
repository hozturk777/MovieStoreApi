using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;

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
            var movieList = _movieContext.Movies.Include(x => x.MovieGenre).OrderBy(x => x.Id).ToList();
            List<MovieViewModel> movieViewModels = _mapper.Map<List<MovieViewModel>>(movieList);
            //List<MovieViewModel> bvm = new List<MovieViewModel>();
            //foreach (var book in movieList)
            //{
            //    bvm.Add(new MovieViewModel()
            //    {
            //        MovieName = book.MovieName,
            //        //Genre = ((GenreEnum)book.GenreId).ToString(),
            //       //PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
            //        Price= (int)book.Price
            //    });
            //}
            return movieViewModels;
        }

        public class MovieViewModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public string? MovieGenre { get; set; }
            //public string? MovieDirector { get; set; }
            //public string? MovieActor { get; set; }
            //public string? PublishDate { get; set; }
        }

    }
}
