using Microsoft.AspNetCore.Mvc;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<List<OrderItem>> GetByIdAsync(string orderID);
    Task UpdateAsync(string orderID, List<OrderItem> orderItems);
    Task AddToOrderAsync(Product product, string orderID);
    Task CheckOut(Order order, string orderID);
}
