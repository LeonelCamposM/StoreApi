using Microsoft.AspNetCore.Mvc;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync(string category, string orderBy);
}