using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

[FirestoreData]
public class Order
{

    [FirestoreProperty]
    [Required(ErrorMessage = "Id is required")]
    public string Id { get; set; }

    [FirestoreProperty]
    [Required(ErrorMessage = "Adress is required")]
    public string Adress { get; set; }

    [FirestoreProperty]
    [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive value")]
    public double Total { get; set; }

    [FirestoreProperty]
    [Required(ErrorMessage = "Date is required")]
    public string Date { get; set; }

    [FirestoreProperty]
    [EmailAddress]
    public string Email { get; set; }


    public Order(string id, string adress, double total, string date, string email)
    {
        Id = id;
        Adress = adress;
        Total = total;
        Date = date;
        Email = email;
    }

    public Order()
    {
        Id = "";
        Adress = "";
        Total = 0;
        Date = "";
        Email = "";
    }
}

