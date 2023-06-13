namespace GrpcService1.Infrastructre
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
