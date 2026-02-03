namespace TeaSaloon_API.Models
{
    public class Tea : Product
    {
        public bool IsPreSet { get; set; }
        public bool IsIced { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}
