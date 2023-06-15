namespace GrpcService.Repos
{
    public interface IProductRepository
    {
        Product GetById(string orderId);
    }
}
