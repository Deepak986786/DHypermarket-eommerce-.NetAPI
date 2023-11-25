public interface INoSqlRepository
{
    Task<User> GetByIdAsync(string id);
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteAsync(string id);
     User GetUserByEmail(string email);
}