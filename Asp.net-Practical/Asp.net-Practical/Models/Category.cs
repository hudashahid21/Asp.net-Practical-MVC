namespace Asp.net_Practical.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Product> Products { get; set; }
    }

}
