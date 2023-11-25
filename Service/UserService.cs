
public class UserService : IUserService
{
    public readonly INoSqlRepository _repository;
    public UserService(INoSqlRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        var userObject = await _repository.AddAsync(user);
        return userObject;
    }

    public async Task DeleteUserAsync(string id)
    {
        await _repository.DeleteAsync(id).ConfigureAwait(false);
    }

    public async Task<User> GetUserByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        return await _repository.UpdateAsync(user);
    }

    public Task<User> LoginAsync(string email, string password)
    {
        var user = _repository.GetUserByEmail(email);

        if (user != null && user.Password == password)
        {
            // Authentication successful
            return Task.FromResult(user);
        }

        // Authentication failed
        return null;
    }
}