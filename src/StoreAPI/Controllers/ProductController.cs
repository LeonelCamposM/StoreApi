using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Product>> Get()
        {
            var eventId = new EventId(0001, "RequestedProducts");
            IEnumerable < Product > products =  await _productService.GetAllAsync();
            _logger.LogInformation(eventId, "products requested  at: {time} :  ", DateTimeOffset.UtcNow);
            return  products;
        }
    }
}