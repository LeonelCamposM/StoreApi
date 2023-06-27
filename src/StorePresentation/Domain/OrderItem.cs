namespace StorePresentation.Domain
{
    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Quantity { get; set; }

        public OrderItem(string id, string name, double price, double stock, string image, string description, string category, double quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Image = image;
            Description = description;
            Category = category;
            Quantity = quantity;
        }
    }
}
