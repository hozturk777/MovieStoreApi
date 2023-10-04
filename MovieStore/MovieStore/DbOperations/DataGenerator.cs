using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                if (context.Movies == null)
                {
                    return;
                }
                context.Actors.AddRange
                    (
                    new Actor
                    {
                        ActorName = "Hüseyin",
                        ActorSurname = "Öztürk",
                    },
                    new Actor
                    {
                        ActorName = "Hüseyin",
                        ActorSurname = "Öztürk",
                    }
                    );
                context.Genres.AddRange
                    (
                    new Genre
                    {
                        GenreName = "Action"
                    },
                    new Genre
                    {
                        GenreName = "Animated"
                    }
                    new Genre
                    {
                        GenreName = "Comedy"
                    }
                    );
                context.Movies.AddRange
                    (
                    new Movie
                    {
                        MovieName = "Berru",
                        MovieGenreId = 1,
                        PublishDate = new DateTime(2001, 05, 30),
                        Price = 15
                    }
                    );
            }
        }
    }
}
