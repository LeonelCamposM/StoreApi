using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;
using Timestamp = Google.Protobuf.WellKnownTypes.Timestamp;

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
    public Timestamp Date { get; set; }

    [FirestoreProperty]
    [EmailAddress]
    public string Email { get; set; }


    public Order(string adress, double total, Timestamp date, string email)
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
        Date = DateTime.Now.ToTimestamp();
        Email = "";
    }
}

