using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Repositories;
using System.Runtime.InteropServices;

public interface IProductService
{

    public Task PopulateProductFromFakeStore();
    public Task<IEnumerable<Product>> GetAllProductAsync([Optional] string[] filter);
    public  Task<Product> CreateProductAsync(string name, Money price, int stock, string imageUrl);
    public  Task DeleteAllProductAsync();
    public Task<Product> IncrementStockAsync(Guid productId, int stock);

    public  Task<Product> DecrementStockAsync(Guid productId, int stock);
    
}
