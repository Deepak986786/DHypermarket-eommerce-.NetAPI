
public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string apiKey;
    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        apiKey = configuration["ApiKeys:ApiKey"];
    }

    public async Task Invoke(HttpContext context)
    {
        var incomingApiKey = context.Request.Headers["ApiKey"].ToString();
        // Check if the API key is valid
        if (string.IsNullOrEmpty(incomingApiKey) || !incomingApiKey.Equals(apiKey, StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Invalid API key.");
            return;
        }

        // Continue to the next middleware if the API key is valid
        await _next(context);
    }
}