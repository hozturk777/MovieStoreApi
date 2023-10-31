using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public ICollection<Movie>? CustomerCart { get; set; }
        public ICollection<Genre>? CustomerFavGenres { get; set; }
        //public bool IsActive { get; set; } = true;
    }
}
