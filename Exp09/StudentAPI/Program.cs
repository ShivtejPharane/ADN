var builder = WebApplication.CreateBuilder(args);

// Add MVC Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Map controller routes
app.MapControllers();

app.Run();
