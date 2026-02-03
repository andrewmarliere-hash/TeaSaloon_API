using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaSaloon_API.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string PaymentMode { get; set; }

        public DateTime OrderCreationTime { get; set; } = DateTime.Now;

        public DateTime Reservation { get; set; }

        [MaxLength(500)]
        [MinLength(2)]
        public string Comment { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();


    }
}
