using System.ComponentModel.DataAnnotations;

namespace StorePresentation.Domain
{
    public class Product
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public double Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Stock must be a positive value")]
        public double Stock { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Image must be a valid URL")]
        public string Image { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public Product(string id, string name, double price, double stock, string image, string description, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Image = image;
            Description = description;
            Category = category;
        }
    }
}
