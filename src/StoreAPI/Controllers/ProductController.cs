using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

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
                IEnumerable<Product> products = await _productService.GetAllAsync(category, orderBy); ;
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
            var eventId = new EventId(0001, "RequestedProducts");
           
            //_logger.LogInformation(eventId, "products requested  at: {time} :  ", DateTimeOffset.UtcNow);
            //_logger.LogWarning("This is a warning message.");
            //_logger.LogError("This is a error message.");
            //return Ok(products);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Retrieve a product by its ID
            // ...
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            // Update a product by its ID
            // ...
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Delete a product by its ID
            // ...
            return Ok();
        }
    }
}