public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(string id);
    Task AddProductAsync(Product product);
    Task AddManyProductsAsync(List<Product> products);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductByIdAsync(string id);
    Task<List<Product>> GetProductsByCategory(string category);
    Task<List<string>> GetCategoryList();
}