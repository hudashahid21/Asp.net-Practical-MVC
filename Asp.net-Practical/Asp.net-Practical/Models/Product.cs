namespace Asp.net_Practical.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Foreign Keys
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}

