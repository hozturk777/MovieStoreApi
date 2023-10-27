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

            //döngüden kurtulmak için DTO kullanılabilir. Veya automapper kullanıp include'yi kullanma



            //return movieList;
            List<MovieDetailsViewModel> movieDetails = _mapper.Map<List<MovieDetailsViewModel>>(movieList);
            return movieDetails;
        }



        public class MovieDetailsViewModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public string? MovieGenre { get; set; }
            public string? MovieDirector { get; set; }
            public ICollection<ActorNameViewModel>? MovieActor { get; set; }
            public string? PublishDate { get; set; }

        }

        public class ActorNameViewModel
        {
            public string? ActorName { get; set; }
            public string? ActorSurname { get; set; }
        }
    }
}
