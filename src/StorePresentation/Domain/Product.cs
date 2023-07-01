using System.ComponentModel.DataAnnotations;

namespace StorePresentation.Domain
{
    public class Product
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo")]
        public double Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El stock debe ser un valor positivo")]
        public double Stock { get; set; }

        [Required(ErrorMessage = "La URL de la imagen es obligatoria")]
        [Url(ErrorMessage = "La imagen debe ser una URL válida")]
        public string Image { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
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
