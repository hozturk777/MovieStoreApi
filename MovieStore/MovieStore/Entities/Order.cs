using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Customer> OrderCustomer { get; set; }
        public ICollection<Movie> OrderMovie { get; set; }

        public DateTime SellTime { get; set; }
    }
}
