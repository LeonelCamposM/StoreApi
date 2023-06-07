using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

[FirestoreData]
public class Product
{
    [FirestoreProperty]
	[Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [FirestoreProperty]
	[Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
    public double Price { get; set; }

    [FirestoreProperty]
	[Range(0, double.MaxValue, ErrorMessage = "Stock must be a positive value")]
    public double Stock { get; set; }

    [FirestoreProperty]
	[Required(ErrorMessage = "Image URL is required")]
    [Url(ErrorMessage = "Image must be a valid URL")]
    public string Image { get; set; }

    [FirestoreProperty]
	[Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    [FirestoreProperty]
	[Required(ErrorMessage = "Category is required")]
    public string Category { get; set; }


    public Product(string name, double price, double stock, string image, string description, string category)
    {
        Name = name;
        Price = price;
        Stock = stock;
        Image = image;
        Description = description;
        Category = category;
    }

    public Product() {
        Name = "";
        Price = 0;
        Stock = 0;
        Image = "";
        Description = "";
        Category = "";
    }
}
