using Microsoft.EntityFrameworkCore;
using TeaSaloon_API.Models;

namespace TeaSaloon_API.Data
{
    public class TeaSaloonContext : DbContext
    {
        public TeaSaloonContext (DbContextOptions<TeaSaloonContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Tea> Teas => Set<Tea>();
        public DbSet<User> Users => Set<User>();
    }
}
