namespace StorePresentation.Domain
{
    public class Order
    {
        public string Address { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }

        public Order(string address, double total, DateTime date, string email)
        {
            Address = address;
            Total = total;
            Date = date;
            Email = email;
        }
    }
}
