public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}
