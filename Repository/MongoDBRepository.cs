
using MongoDB.Driver;

public class MongoDBRepository : INoSqlRepository
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<User> _user;
    public MongoDBRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDB"));
        _database = client.GetDatabase("EcommerceDatabase");
        _user = _database.GetCollection<User>("Users");
    }

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

    public  User GetUserByEmail(string email)
    {
        return  _user.Find(user => user.Email == email).FirstOrDefault();
    }

    public Task<User> UpdateAsync(User user)
    {
        _user.ReplaceOne(obj => obj.Id == user.Id, user);
        return Task.FromResult(user);
    }
}
