using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieStore.Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ActorName { get; set; }
        public string? ActorSurname { get; set; }
        //public List<Movie>? ActorMovie { get; set; }

        [JsonIgnore] //actoru çekerken movieleri gelmez burada 
        public ICollection<Movie> ActorMovie { get; set; }

        public int? ActorMovieId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
