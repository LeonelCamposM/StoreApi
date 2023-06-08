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

    public async Task AddAsync(Product product)
    {
        //await _productRepository.AddAsync(product);
    }

    public async Task DeleteAsync(string id)
    {
        //await _productRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(string id, Product product)
    {
        //await _productRepository.UpdateAsync(product);
    }
    public async Task<Product> GetByidAsync(string id)
    {
        //await _productRepository.UpdateAsync(product);
        return null;
    }
}