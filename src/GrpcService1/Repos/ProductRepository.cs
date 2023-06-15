namespace GrpcService.Repos
{
    public class ProductRepository : IProductRepository
    {
        public Product GetById(string orderId)
        {
            Product product = new Product();
            product.Id = orderId;
            product.Name = "Test";
            product.Price = 100;
            product.Stock = 100;
            return product;
        }
    }
}
