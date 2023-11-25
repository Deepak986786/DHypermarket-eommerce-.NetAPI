public interface IUserService
{
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(string id);
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserByIdAsync(string id);
    Task<User> LoginAsync(string email, string password);
}