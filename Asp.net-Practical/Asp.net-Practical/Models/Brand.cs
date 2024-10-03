namespace Asp.net_Practical.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Product> Products { get; set; }
    }

}
