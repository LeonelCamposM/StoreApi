using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get()
        {
            var eventId = new EventId(0001, "RequestedOrders");
            try
            {
                IEnumerable<Order> orders = await _orderService.GetAllAsync();
                _logger.LogInformation(eventId, "Orders requested at: {time}", DateTimeOffset.UtcNow);
                if (orders == null || !orders.Any())
                {
                    _logger.LogInformation(eventId, "No orders found at: {time}", DateTimeOffset.UtcNow);
                    return StatusCode((int)HttpStatusCode.NotFound, "No orders found");
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while retrieving orders");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var eventId = new EventId(0003, "GetOrderById");
            try
            {
                Order order = await _orderService.GetByIdAsync(id);
                if (order == null)
                {
                    _logger.LogInformation(eventId, "No order found with ID {id} at: {time}", id, DateTimeOffset.UtcNow);
                    return StatusCode((int)HttpStatusCode.NotFound, $"No order found with ID {id}");
                }
                _logger.LogInformation(eventId, "Order with ID {id} requested at: {time}", id, DateTimeOffset.UtcNow);
                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while retrieving order with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Order order)
        {
            var eventId = new EventId(0004, "UpdateOrder");
            try
            {
                await _orderService.UpdateAsync(id, order);
                _logger.LogInformation(eventId, "Order with ID {id} updated at: {time}", id, DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while updating order with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpPost("{orderId}/checkOut")]
        public async Task<IActionResult> CheckOut(string orderId)
        {
            var eventId = new EventId(0006, "CheckOutOrder");
            try
            {
                await _orderService.CheckOut(orderId);
                _logger.LogInformation(eventId, "Order checked out at: {time}", DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while checking out order");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }
    }
}