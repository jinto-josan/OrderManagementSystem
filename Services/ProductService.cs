using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Repositories;
using Services.Dto;
using System.Net.Http.Json;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper, HttpClient client )
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _httpClient= client;
    }

    public async Task PopulateProductFromFakeStore()
    {
        if (!await _productRepository.AnyDataExistAsync())
        {
            var res = (await _httpClient.GetAsync("https://fakestoreapi.com/products")).EnsureSuccessStatusCode();
            var data = await res.Content.ReadFromJsonAsync<List<FakeStoreDto>>();

            await _productRepository.AddAllAsync(_mapper.Map<List<Product>>(data));
        }

    }

    public async Task DeleteAllProductAsync()
    {
        var data = await _productRepository.GetAllAsync();
        foreach(var item in data)
            await _productRepository.DeleteAsync(item.Id);
    }

    public async Task<IEnumerable<Product>> GetAllProductAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> CreateProductAsync(string name, Money price, int stock,string imageUrl)
    {
        var product = new Product(name, stock) { ImageUrl=imageUrl};
        product.UpdatePrice(price);
        await _productRepository.AddAsync(product);
        return product;
    }

    public async Task<Product> IncrementStockAsync(Guid productId, int stock)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product != null)
        {
            product.UpdateStock(product.Stock+stock);
            await _productRepository.UpdateAsync(product);
        }

        return product;
    }
    public async Task<Product> DecrementStockAsync(Guid productId, int stock)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product != null)
        {
            product.UpdateStock(product.Stock-stock);
            await _productRepository.UpdateAsync(product);
        }

        return product;
    }
}
