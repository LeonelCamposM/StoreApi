using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;
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
        public async Task<IActionResult> Get()
        {
            var eventId = new EventId(0001, "RequestedProducts");
			try
			{
				IEnumerable<Product> products = await _productService.GetAllAsync();
				_logger.LogInformation(eventId, "Products requested at: {time}", DateTimeOffset.UtcNow);
				if (products == null || !products.Any())
				{
					_logger.LogInformation(eventId, "No products found at: {time}", DateTimeOffset.UtcNow);
					return StatusCode((int)HttpStatusCode.NotFound, "No products found"); // HTTP 404 Not Found status
				}
				return Ok(products); // HTTP 200 OK status
			}
			catch (Exception ex)
			{
				_logger.LogError(eventId, ex, "An error occurred while retrieving products");
				return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred"); // HTTP 500 Internal Server Error status
			}
        }
    }
}