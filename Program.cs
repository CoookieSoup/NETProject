using Microsoft.EntityFrameworkCore;
using NETProject.Data;  // Change "YourProjectName" to your actual project name

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=transactions.db"));

var app = builder.Build();

// You can remove or keep the Hello World endpoint
// app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();