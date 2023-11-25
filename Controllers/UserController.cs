
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var userList = await _userService.GetUsersAsync();
            return Ok(userList);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("getUserById")]
    public async Task<IActionResult> GetUserByIdAsync(string id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        catch (System.Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("createUser")]
    public async Task<IActionResult> CreateUserAsync([FromBody] User user)
    {
        try
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPut("updateUser")]
    public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
    {
        try
        {
            var updatedUser = await _userService.UpdateUserAsync(user);
            return Ok(updatedUser);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        // Validate the request
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Email and password are required.");
        }
        // Authenticate the user
        var user = await _userService.LoginAsync(request.Email, request.Password);

        if (user != null)
        {
            // Return the authenticated user
            return Ok(user);
        }
        return Unauthorized("Invalid email or password");
    }



}