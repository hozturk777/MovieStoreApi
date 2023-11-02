using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerSurname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public int? CustomerCartId { get; set; } = null;
        public ICollection<Movie>? CustomerCart { get; set; }
        public ICollection<Genre>? CustomerFavGenres { get; set; }
        //public bool IsActive { get; set; } = true;
    }
}
