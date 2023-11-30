
using MongoDB.Driver;

public class MongoDBRepository : INoSqlRepository
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<User> _user;
    private readonly IMongoCollection<Product> _products;
    public MongoDBRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = client.GetDatabase("EcommerceDatabase");
        _user = _database.GetCollection<User>("Users");
        _products = _database.GetCollection<Product>("Products");
    }

    //  USER MEthods

    public async Task<User> AddAsync(User user)
    {
        _user.InsertOne(user);
        return user;
    }
    public Task DeleteAsync(string id)
    {
        _user.DeleteOne(user => user.Id == id);
        return Task.CompletedTask;
    }
    public async Task<List<User>> GetAllAsync()
    {
        var userList = _user.Find(user => true).ToList();
        return userList;
    }

    public Task<User> GetByIdAsync(string id)
    {
        // var user = _user.Find<User>(obj => obj.Email == id).FirstOrDefault();
        var user = _user.Find<User>(obj => obj.Id == id).FirstOrDefault();
        return Task.FromResult(user);
    }

    public User GetUserByEmail(string email)
    {
        return _user.Find(user => user.Email == email).FirstOrDefault();
    }

    public Task<User> UpdateAsync(User user)
    {
        _user.ReplaceOne(obj => obj.Id == user.Id, user);
        return Task.FromResult(user);
    }

    //    PRODUCT METHODS
    public async Task AddManyProductsAsync(List<Product> products)
    {
        await _products.InsertManyAsync(products);
    }

    public async Task AddProductAsync(Product product)
    {
        await _products.InsertOneAsync(product);
    }


    public async Task DeleteProductByIdAsync(string id)
    {
        await _products.DeleteOneAsync(product => product.Id == id);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _products.Find<Product>(product => true).ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await _products.Find<Product>(product => product.Id == id).FirstOrDefaultAsync();
    }

    public Task<Product> UpdateProductAsync(Product product)
    {
        _products.ReplaceOne(obj => obj.Id == product.Id, product);
        return Task.FromResult(product);
    }

    public async Task<List<Product>> GetProductsByCategory(string category)
    {
        var filter = Builders<Product>.Filter.Eq(product => product.Category, category);
        return await _products.Find(filter).ToListAsync();
    }

    public async Task<List<string>> GetCategoryList()
    {
        return await _products.Distinct(product => product.Category, Builders<Product>.Filter.Empty).ToListAsync();
    }


}
