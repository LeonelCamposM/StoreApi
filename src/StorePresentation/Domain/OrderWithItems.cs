namespace StorePresentation.Domain
{
    public class OrderWithItems
    {
        public Order OrderInfo { get; set; }
        public List<OrderItem> Items { get; set; }
        public bool ShowOrderItems { get; set; }

        public OrderWithItems(Order order, List<OrderItem> items)
        {
            OrderInfo = order;
            Items = items;
            ShowOrderItems = false;
        }

    }
}
