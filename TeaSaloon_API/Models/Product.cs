using System.ComponentModel.DataAnnotations;

namespace TeaSaloon_API.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [Range(1,50)]
        public double Price { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();



    }
}
