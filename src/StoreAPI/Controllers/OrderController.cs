using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Domain.Order;
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
                List<OrderWithItems> orders = await _orderService.GetAllAsync();
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
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Get(string id)
        {
            var eventId = new EventId(0003, "GetOrderById");
            try
            {
                var order = await _orderService.GetByIdAsync(id);
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
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(string id, [FromBody] List<OrderItem> orderItems)
        {
            var eventId = new EventId(0004, "UpdateOrder");
            try
            {
                await _orderService.UpdateAsync(id, orderItems);
                _logger.LogInformation(eventId, "Order with ID {id} updated at: {time}", id, DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while updating order with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpPost("{id}/CheckOut")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> CheckOut(string id, [FromBody] Order order)
        {
            var eventId = new EventId(0006, "CheckOutOrder");
            try
            {
                await _orderService.CheckOut(order, id);
                _logger.LogInformation(eventId, "Order checked out at: {time}", DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while checking out order");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }


        [HttpPost("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post(string id, [FromBody] Product product)
        {
            var eventId = new EventId(0007, "AddToCart");
            try
            {
                await _orderService.AddToOrderAsync(product, id);
                _logger.LogInformation(eventId, "AddToCart at: {time}", DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while AddToCart ");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }
    }
}