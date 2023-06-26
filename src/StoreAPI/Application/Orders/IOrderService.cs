using Microsoft.AspNetCore.Mvc;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<List<OrderItem>> GetByIdAsync(string orderID);
    Task UpdateAsync(string orderID, Order order);
    Task AddToOrderAsync(Product product, string orderID);
    Task CheckOut(string orderID);
}
