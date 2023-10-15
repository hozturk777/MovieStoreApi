using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {string currentdatetime = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            using (var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                var movie = new List<Movie>
                {
                    new Movie
                    {
                        MovieName = "deneme",
                        Price = 1,
                        MovieGenreId = 2,
                        MovieDirector = "director",
                        MovieActor = "actor",
                        PublishDate = DateTime.Now.ToString("MM/dd/yyyy")

            }
                };
                var genre = new List<Genre>
                {
                    new Genre
                    {
                        Id = 1,
                        GenreName = "Genre1"
                    },
                    new Genre
                    {
                        Id = 2,
                        GenreName = "Genre2"
                    }
                };
                context.Movies.AddRange(movie);
                context.Genres.AddRange(genre);
                context.SaveChanges();
            }
        }
    }
}
