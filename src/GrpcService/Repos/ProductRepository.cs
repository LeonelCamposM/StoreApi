namespace GrpcService.Repos
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetByID(string id)
        {
            Product product = new Product();
            product.Id = "";
            product.Name = "grpc product";
            product.Stock = 100;
            product.Price = 23;
            return Task.FromResult(product);
        }
    }
}