using System.ComponentModel.DataAnnotations;

namespace TeaSaloon_API.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        public bool IsManager { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
