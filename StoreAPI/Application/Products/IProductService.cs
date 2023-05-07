public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
}