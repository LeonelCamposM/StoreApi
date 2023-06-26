﻿using Microsoft.AspNetCore.Mvc;

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

    public async Task CheckOut(Order order, string orderID)
    {
        await _orderRepository.CheckOut(order, orderID);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<List<OrderItem>> GetByIdAsync(string orderID)
    {
       return await _orderRepository.GetByIdAsync(orderID);
    }

    public async Task UpdateAsync(string orderID, List<OrderItem> orderItems)
    {
         await _orderRepository.UpdateAsync(orderID, orderItems);
    }
}