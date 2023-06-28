using Microsoft.AspNetCore.Mvc;
using StoreAPI.Domain.Order;

public interface IOrderService
{
    Task<List<OrderWithItems>> GetAllAsync();
    Task<List<OrderItem>> GetByIdAsync(string orderID);
    Task UpdateAsync(string orderID, List<OrderItem> orderItems);
    Task AddToOrderAsync(Product product, string orderID);
    Task CheckOut(Order order, string orderID);
}
