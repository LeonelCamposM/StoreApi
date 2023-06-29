namespace StoreAPI.Domain.Order
{
    public class OrderWithItems
    {
        public Order OrderInfo { get; set; }
        public List<OrderItem> Items { get; set; }

        public OrderWithItems(Order order, List<OrderItem> items)
        {
            OrderInfo = order;
            Items = items;  
        }

    }
}
