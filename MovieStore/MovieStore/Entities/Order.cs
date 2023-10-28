using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime SellTime { get; set; }
    }
}
