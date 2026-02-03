using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaSaloon_API.Models
{
    public class OrderLine
    {
        [Key]
        public long OrderLineID { get; set; }

        [Required]
        [Range(1, 50)]
        public int Quantity { get; set; }
        
        
        public Product ProductID { get; set; }
        [ForeignKey(ProductID)]

    }
}
