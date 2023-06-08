using Microsoft.AspNetCore.Mvc;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(string category, string orderBy)
    {
        return await _productRepository.GetAllAsync(category, orderBy);
    }
}