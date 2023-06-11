using Microsoft.AspNetCore.Mvc;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(string orderId);
    Task UpdateAsync(string orderID, Order order);
    Task CheckOut(string orderID);
}
