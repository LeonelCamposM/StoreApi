﻿using Microsoft.AspNetCore.Mvc;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task CheckOut(string orderID)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public Task<Order> GetByIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string orderID, Order order)
    {
        throw new NotImplementedException();
    }
}