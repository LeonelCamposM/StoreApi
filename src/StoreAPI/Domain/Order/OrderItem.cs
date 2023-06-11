using Google.Api.Gax.ResourceNames;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Domain.Order
{
    public class OrderItem
    {
        [FirestoreProperty]
        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Image must be a valid URL")]
        public string Image { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "ProductID is required")]
        public string ProductID { get; set; }

        [FirestoreProperty]
        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }

        [FirestoreProperty]
        [Range(0, double.MaxValue, ErrorMessage = "UnitPrice must be a positive value")]
        public double UnitPrice { get; set; }


        [FirestoreProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be a positive value")]
        public double Quantity { get; set; }

        
        [FirestoreProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive value")]
        public double Total { get; set; }


        public OrderItem(double quantity, string productID, double total, string ImageUrl, string productName, double unitPrice)
        {
            Quantity = quantity;
            ProductID = productID;
            Total = total;
            Image = ImageUrl;
            ProductName = productName;
            UnitPrice = unitPrice;
        }

        public OrderItem()
        {
            Quantity = 0;
            ProductID = "";
            Total = 0;
            Image = "google.com";
            ProductName = "";
            UnitPrice = 0;
        }
    }
}
