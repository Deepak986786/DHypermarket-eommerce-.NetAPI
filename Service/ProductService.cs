

using MongoDB.Driver;

public class ProductService : IProductService
{
    public INoSqlRepository _repository { get; }
    public ProductService(INoSqlRepository repository)
    {
        _repository = repository;
    }


    public async Task AddManyProductsAsync(List<Product> products)
    {
        await _repository.AddManyProductsAsync(products);
    }

    public async Task AddProductAsync(Product product)
    {
        await _repository.AddProductAsync(product);
    }

    public async Task DeleteProductByIdAsync(string id)
    {
        await _repository.DeleteProductByIdAsync(id);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllProductsAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await _repository.GetProductByIdAsync(id);
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        return await _repository.UpdateProductAsync(product);
    }

    public async Task<List<Product>> GetProductsByCategory(string category)
    {
        return await _repository.GetProductsByCategory(category);
    }

    public async Task<List<string>> GetCategoryList()
    {
        return await _repository.GetCategoryList();
    }
}