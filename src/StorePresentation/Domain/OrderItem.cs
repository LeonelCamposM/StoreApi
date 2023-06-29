namespace StorePresentation.Domain
{
    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public double Quantity { get; set; }

        public OrderItem(string id, string name, double price, string image, double quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            Quantity = quantity;
        }
    }
}
