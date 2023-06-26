using Microsoft.AspNetCore.Mvc;

public interface IOrderRepository
{

    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int orderId);
    Task UpdateAsync(string orderID, Order order);
    Task AddToOrderAsync(Product product, string orderID);
    Task CheckOut(string orderID);
}

