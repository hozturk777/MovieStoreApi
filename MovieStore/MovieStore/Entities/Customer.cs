using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public Movie? BuyMovies { get; set; }
        public Movie? FavMovies { get; set; }

    }
}
