using Google.Cloud.Firestore;

[FirestoreData]
public class Product
{
    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]
    public double Price { get; set; }

    [FirestoreProperty]
    public double Stock { get; set; }

    [FirestoreProperty]
    public string Image { get; set; }

    [FirestoreProperty]
    public string Description { get; set; }

    [FirestoreProperty]
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
