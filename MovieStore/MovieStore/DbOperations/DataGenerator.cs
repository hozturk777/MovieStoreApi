using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                var movie = new List<Movie>
                {
                    new Movie
                    {
                        MovieName = "deneme",
                        Price = 1,
                        MovieGenreId = 1,
                        MovieDirector = "director",
                        MovieActor = "actor",
                        PublishDate = DateTime.Now
                    }
                };
                var genre = new List<Genre>
                {
                    new Genre
                    {
                        Id = 1,
                        GenreName = "Happy"
                    }
                };
                context.Movies.AddRange(movie);
                context.Genres.AddRange(genre);
                context.SaveChanges();
            }
        }
    }
}
