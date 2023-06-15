using Grpc.Core;
using GrpcProductService;

namespace GrpcProductService.Services
{
    public class ProductService : Product.ProductBade
    {
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public override Task<ProductResponse> GetProductByID(ProductRequest request, ServerCallContext context)
        {
            return Task.FromResult(new Product
            {
                Message = "Hello " + request.Name
            });
        }
    }
}