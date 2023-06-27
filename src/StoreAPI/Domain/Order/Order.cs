using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;

[FirestoreData]
public class Order
{

    [FirestoreProperty]
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [FirestoreProperty]
    [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive value")]
    public double Total { get; set; }

    [FirestoreProperty]
    [Required(ErrorMessage = "Date is required")]
    public string Date { get; set; }

    [FirestoreProperty]
    [EmailAddress]
    public string Email { get; set; }


    public Order(string address, double total, string date, string email)
    {

        Address = address;
        Total = total;
        Date = date;
        Email = email;
    }

    public Order()
    {
        
        Address = "";
        Total = 0;
        Date = "";
        Email = "";
    }
}

