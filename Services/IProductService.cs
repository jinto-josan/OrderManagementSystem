using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Repositories;

public interface IProductService
{

    public Task PopulateProductFromFakeStore();
    public Task<IEnumerable<Product>> GetAllProductAsync();
    public  Task<Product> CreateProductAsync(string name, Money price, int stock, string imageUrl);
    public  Task DeleteAllProductAsync();
    public Task<Product> IncrementStockAsync(Guid productId, int stock);

    public  Task<Product> DecrementStockAsync(Guid productId, int stock);
    
}
