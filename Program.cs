var builder = WebApplication.CreateBuilder(args);

// Adding Logger
// var logger = new LoggerConfiguration().

// Add services to the container.
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IProductService,ProductService>();
builder.Services.AddSingleton<INoSqlRepository, MongoDBRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "abcdefghijklmnopqrstuvwxyz"));
}

// app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(opt=>{
    opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.MapControllers();

app.Run();
