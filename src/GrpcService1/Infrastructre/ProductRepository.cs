

namespace GrpcService1.Infrastructre
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            Product product = new Product();
            Product product1 = new Product();
            product.Id = 1;
            product.Name = "Test";
            product.Price = 100;
            product.Stock = 100;

            product.Id = 2;
            product.Name = "Test1";
            product.Price = 200;
            product.Stock = 200;
            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product);

            return products;

        }
    }
}
