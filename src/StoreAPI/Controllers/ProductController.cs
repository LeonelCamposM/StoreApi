using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string category, [FromQuery] string orderBy)
        {
            var eventId = new EventId(0001, "RequestedProducts");
            try
            {
                IEnumerable<Product> products = await _productService.GetAllAsync(category, orderBy);
                _logger.LogInformation(eventId, "Products requested at: {time}", DateTimeOffset.UtcNow);
                if (products == null || !products.Any())
                {
                    _logger.LogInformation(eventId, "No products found at: {time}", DateTimeOffset.UtcNow);
                    return StatusCode((int)HttpStatusCode.NotFound, "No products found");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while retrieving products");
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var eventId = new EventId(0002, "AddProduct");
            try
            {
                await _productService.AddAsync(product);
                _logger.LogInformation(eventId, "Product added at: {time}", DateTimeOffset.UtcNow);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while adding product");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var eventId = new EventId(0003, "GetProductByID");
            try
            {
                Product product = await _productService.GetByidAsync(id);
                if (product == null)
                {
                    _logger.LogInformation(eventId, "No product found with ID {id} at: {time}", id, DateTimeOffset.UtcNow);
                    return StatusCode((int)HttpStatusCode.NotFound, $"No product found with ID {id}");
                }
                _logger.LogInformation(eventId, "Product with ID {id} requested at: {time}", id, DateTimeOffset.UtcNow);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while retrieving product with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            var eventId = new EventId(0004, "UpdateProduct");
            try
            {
                await _productService.UpdateAsync(id, product);
                _logger.LogInformation(eventId, "Product with ID {id} updated at: {time}", id, DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while updating product with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var eventId = new EventId(0005, "DeleteProduct");
            try
            {
                await _productService.DeleteAsync(id);
                _logger.LogInformation(eventId, "Product with ID {id} deleted at: {time}", id, DateTimeOffset.UtcNow);
                _logger.LogWarning(eventId, "Product with ID {id} deleted at: {time}", id, DateTimeOffset.UtcNow);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(eventId, ex, "An error occurred while deleting product with ID {id}", id);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Not implemented endpoint");
            }
        }
    }
}