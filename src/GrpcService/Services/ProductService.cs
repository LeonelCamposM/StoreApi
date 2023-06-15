using Grpc.Core;
using GrpcService;
using GrpcService.Repos;

namespace GrpcService.Services
{
    public class ProductService : Products.ProductsBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public override async Task<ProductResponse> Get(ProductRequest request, ServerCallContext context)
        {
            return new ProductResponse
            {
                Product = await _productRepository.GetByID(request.ProductID)
            };
        }
    }
}