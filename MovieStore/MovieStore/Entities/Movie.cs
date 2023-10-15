using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public float Price { get; set; }
        public string PublishDate { get; set; }
        public int MovieGenreId { get; set; }
        public Genre? MovieGenre { get; set; }
        public string? MovieDirector { get; set; }
        public string? MovieActor { get; set; }
    }
}
 