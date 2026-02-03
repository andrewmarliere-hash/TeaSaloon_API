using System.ComponentModel.DataAnnotations;

namespace TeaSaloon_API.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range (0, 50)]
        public double SuplementPrice { get; set; }

        [Required]
        [Range(0,50)]
        public double Price { get; set; }

        public string Image { get; set; }

        public ICollection<Tea> Teas { get; set; } = new List<Tea>();

    }
}
