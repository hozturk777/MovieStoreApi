using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;
using System.Collections;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {

                //  GENRE
                //var genre = new List<Genre>
                context.Genres.AddRange
                (
                    new Genre
                    {
                        GenreName = "Genre1"
                    },
                    new Genre
                    {
                        GenreName = "Genre2"
                    }
                );


                //  ACTOR
                //var actor = new List<Actor>
                context.Actors.AddRange
                (
                    new Actor
                    {
                        ActorName = "Actor1",
                        ActorSurname = "Actor1",
                        //IdId = context.Actors.
                        //ActorMovie = new List<Movie>(),
                        //ActorMovieId = new List<MovieId>()
                        //MoviesId = new List<int> {1, 2}
                    },
                    new Actor
                    {
                        ActorName = "Actor2",
                        ActorSurname = "Actor2",
                        //ActorMovie = new List<Movie>(),
                        //ActorMovieId = new List<MovieId>()
                        //MoviesId = new List<int> {1, 2}
                    }
                ); 
                context.SaveChanges();
                //  DİRECTOR
                context.Directors.AddRange
                    (
                        new Director
                        {
                            DirectorName = "Director1",
                            DirectorSurname = "Director1"
                        },
                        new Director
                        {
                            DirectorName = "Director2",
                            DirectorSurname = "Director2"
                        }
                    );
                context.SaveChanges();

                //  MOVİE
                //var movie = new List<Movie>
                context.Movies.AddRange
                (
                    new Movie
                    {
                        MovieName = "movie1",
                        Price = 113,
                        MovieGenreId = 1,
                        PublishDate = DateTime.Now.ToString("MM/dd/yyyy"),
                        MovieActor = new List<Actor>(),
                        MovieDirector = new List<Director>()
                    },
                    new Movie
                    {
                        MovieName = "movie2",
                        Price = 3123,
                        MovieGenreId = 2,
                        PublishDate = DateTime.Now.ToString("MM/dd/yyyy"),
                        MovieActor = new List<Actor>(),
                        MovieDirector = new List<Director>()
                    }
                    
                ) ;
                
                //context.Genres.AddRange(genre);
                //context.Actors.AddRange(actor);
                //context.Movies.AddRange(movie);
                context.SaveChanges();
            }
        }
    }
}
