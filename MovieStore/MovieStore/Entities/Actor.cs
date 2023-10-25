using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? den { get; set; }
        public string? ActorName { get; set; }
        public string? ActorSurname { get; set; }
        public List<Movie>? ActorMovie { get; set; }

        public List<MovieId>? ActorMovieId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
