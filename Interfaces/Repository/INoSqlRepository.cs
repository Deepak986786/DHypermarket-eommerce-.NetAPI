public interface INoSqlRepository
{
    // For User Collection
    Task<User> GetByIdAsync(string id);
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(string id);
    User GetUserByEmail(string email);

    // For Product Collection
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(string id);
    Task AddProductAsync(Product product);
    Task AddManyProductsAsync(List<Product> products);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductByIdAsync(string id);
    Task<List<Product>> GetProductsByCategory(string category);
    Task<List<string>> GetCategoryList();

}