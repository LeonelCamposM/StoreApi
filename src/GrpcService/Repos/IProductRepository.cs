namespace GrpcService.Repos
{
    public interface IProductRepository
    {
        Task<Product> GetByID(string id);
    }
}
