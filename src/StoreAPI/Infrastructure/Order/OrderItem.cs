using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

[FirestoreData]
public class OrderItem
{
    [FirestoreProperty]
    [Required(ErrorMessage = "Id is required")]
    public string Id { get; set; }

    [FirestoreProperty]
	[Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [FirestoreProperty]
	[Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
    public double Price { get; set; }

    [FirestoreProperty]
	[Required(ErrorMessage = "Image URL is required")]
    [Url(ErrorMessage = "Image must be a valid URL")]
    public string Image { get; set; }

    [FirestoreProperty]
    [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a positive value")]
    public double Quantity { get; set; }


    public OrderItem(string id, string name, double price, string image, double quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Image = image;
        Quantity = quantity;
    }

    public OrderItem() {
        Id = "";
        Name = "";
        Price = 0;
        Image = "";
        Quantity = 0;
    }
}
