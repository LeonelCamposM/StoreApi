using Microsoft.AspNetCore.Mvc;

public interface IOrderRepository
{

    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int orderId);
    Task UpdateAsync(string orderID, Order order);
    Task CheckOut(string orderID);
}

