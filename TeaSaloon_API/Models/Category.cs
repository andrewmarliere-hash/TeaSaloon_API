using System.ComponentModel.DataAnnotations;

namespace TeaSaloon_API.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
