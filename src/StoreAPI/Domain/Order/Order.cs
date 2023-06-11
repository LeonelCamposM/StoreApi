using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

[FirestoreData]
public class Order
{

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


    public Order(string adress, double total, string date, string email)
    {
        Adress = adress;
        Total = total;
        Date = date;
        Email = email;
    }

    public Order()
    {
        Adress = "";
        Total = 0;
        Date = "";
        Email = "";
    }
}

