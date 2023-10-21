using MovieStore.DbOperations;

namespace MovieStore.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMoviesQuery
    {
        private readonly IMovieContext _context;
        public int MovieId { get; set; }

        public DeleteMoviesQuery(IMovieContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movieDelete = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movieDelete is null) 
            {
                throw new InvalidOperationException("Böyle Bir Film Yok!");
            }
            movieDelete.IsActive = false;
            _context.SaveChanges();
        }
    }
}
