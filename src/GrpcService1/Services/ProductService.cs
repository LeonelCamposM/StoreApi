using Grpc.Core;
using GrpcService1.Infrastructre;
using System.Text.RegularExpressions;

namespace GrpcService1.Services
{
    public class ProductService : Products.ProductsBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public override async Task<AllProductsResponse> GetAll(AllProductsRequest request, ServerCallContext context)
        {
            var response = new AllProductsResponse();
            response.Product = _productRepository.GetAll().First();
            return response;
        }
    }
}