using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMoviesQuery
    {
        private readonly IMovieContext _context;
        public int MovieId { get; set; }
        public UpdateMovieViewModel Model { get; set; }

        public UpdateMoviesQuery(IMovieContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movieUpdate = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movieUpdate is null)
            {
                throw new InvalidOperationException("Böyle Bir Film Yok!");
            }
            movieUpdate.MovieName = Model.MovieName != default ? Model.MovieName : movieUpdate.MovieName;
            movieUpdate.Price = Model.Price != default ? Model.Price : movieUpdate.Price;
            movieUpdate.MovieGenreId = Model.MovieGenreId != default ? Model.MovieGenreId : movieUpdate.MovieGenreId;
            movieUpdate.MovieDirector = Model.MovieDirector != default ? Model.MovieDirector : movieUpdate.MovieDirector;
            movieUpdate.MovieActorId = Model.MovieActorId != default ? Model.MovieActorId : movieUpdate.MovieActorId;

            ICollection<Actor> actors = new List<Actor>();
            Actor actor = GetActorByID(movieUpdate.MovieActorId);
            actors.Add(actor);

            movieUpdate.MovieActor = actors;

            _context.SaveChanges();
        }

        public Actor GetActorByID(int? movieActorId)
        {
            List<Actor> actors = new List<Actor>();
            if (movieActorId != null)
            {
                Actor actor = _context.Actors.SingleOrDefault(x => x.Id == movieActorId);

                return actor;
            }
            else { return null; }

        }

        public class UpdateMovieViewModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public int? MovieGenreId { get; set; }
            public string? MovieDirector { get; set; }
            public int? MovieActorId { get; set; }
        }
    }
}
