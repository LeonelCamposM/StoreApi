using Microsoft.AspNetCore.Mvc;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task AddToOrderAsync(Product product, string orderID)
    {
        await _orderRepository.AddToOrderAsync(product, orderID);
    }

    public Task CheckOut(string orderID)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<List<OrderItem>> GetByIdAsync(string orderID)
    {
       return await _orderRepository.GetByIdAsync(orderID);
    }

    public Task UpdateAsync(string orderID, Order order)
    {
        throw new NotImplementedException();
    }
}