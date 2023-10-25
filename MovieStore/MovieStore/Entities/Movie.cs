using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public float Price { get; set; }
        public string? PublishDate { get; set; }
        public int? MovieGenreId { get; set; } = null;
        public Genre? MovieGenre { get; set; } = null;
        public string? MovieDirector { get; set; } = null;
        public int? MovieActorId { get; set; } = null;
        public IEnumerable<Actor>? MovieActor {  get; set; } = null;

        

        public bool IsActive { get; set; } = true;
        

    }
}
 