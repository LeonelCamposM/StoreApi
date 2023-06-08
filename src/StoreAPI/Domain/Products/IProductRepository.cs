using Microsoft.AspNetCore.Mvc;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(string category, string orderBy);
}
