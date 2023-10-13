using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
        public int MovieGenreId { get; set; }
        public Genre? MovieGenre { get; set; }
        public Director? MovieDirector { get; set; }
        public Actor? MovieActor { get; set; }
    }
}
 