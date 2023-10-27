using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? DirectorName { get; set; }
        public string? DirectorSurname { get; set; }
        public ICollection<Movie>? DirectorMovie { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
