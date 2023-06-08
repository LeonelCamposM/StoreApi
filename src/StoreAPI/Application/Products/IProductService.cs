using Microsoft.AspNetCore.Mvc;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync(string category, string orderBy);
    Task AddAsync(Product product);
    Task DeleteAsync(string id);
    Task UpdateAsync(string id, Product product);
    Task<Product> GetByidAsync(string id);
}
