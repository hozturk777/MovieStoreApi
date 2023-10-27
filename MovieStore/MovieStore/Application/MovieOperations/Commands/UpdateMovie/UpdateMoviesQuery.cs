using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using static MovieStore.Application.MovieOperations.Quaries.GetMoviesDetails.GetMoviesDetailsQuery;

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
            movieUpdate.MovieActorId = Model.MovieActorId != default ? Model.MovieActorId : movieUpdate.MovieActorId;
            movieUpdate.MovieDirectorId = Model.MovieDirectorId != default ? Model.MovieDirectorId : movieUpdate.MovieDirectorId;

            //  MovieActor in Movie
            ICollection<Actor> actors = new List<Actor>();
            Actor actor = GetActorByID(movieUpdate.MovieActorId);
            actors.Add(actor);
            movieUpdate.MovieActor = actors;

            //  MovieDirector in Movie
            ICollection<Director> directors = new List<Director>();
            Director director = GetDirectorByID(movieUpdate.MovieDirectorId);
            directors.Add(director);
            movieUpdate.MovieDirector = directors;

            // ActorMovie in Actor
            var actorMovieUpdate = _context.Actors.SingleOrDefault(x => x.Id == movieUpdate.MovieActorId);
            ICollection<Movie> actorMovieList = new List<Movie>();
            Movie actorMovie= movieUpdate;
            actorMovieList.Add(actorMovie);
            actorMovieUpdate.ActorMovie = actorMovieList != default ? actorMovieList : actorMovieUpdate.ActorMovie;

            //  DirectorMovie in Director
            var directorMovieUpdate = _context.Directors.SingleOrDefault(x => x.Id == movieUpdate.MovieDirectorId);
            ICollection<Movie> directorMovieList = new List<Movie>();
            Movie directorMovie = movieUpdate;
            directorMovieList.Add(directorMovie);
            directorMovieUpdate.DirectorMovie = directorMovieList != default ? directorMovieList : directorMovieUpdate.DirectorMovie;
            

            _context.SaveChanges();
        }

        //  MovieActor Func
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

        //  MovieDirector Func
        public Director GetDirectorByID(int? movieDirectorId)
        {
            List<Director> actors = new List<Director>();
            if (movieDirectorId != null)
            {
                Director director = _context.Directors.SingleOrDefault(x => x.Id == movieDirectorId);

                return director;
            }
            else { return null; }
        }

        public class UpdateMovieViewModel
        {
            public string? MovieName { get; set; }
            public float Price { get; set; }
            public int? MovieGenreId { get; set; }
            public int? MovieDirectorId { get; set; }
            public int? MovieActorId { get; set; }
        }
    }
}
