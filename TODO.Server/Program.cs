using Microsoft.EntityFrameworkCore;
using TODO.Core.Services;
using TODO.Core.Services.Contracts;
using TODO.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite($"Data Source={builder.Configuration.GetConnectionString("TodoDatabase")}", _ => _.MigrationsAssembly("TODO.Server")));
builder.Services.AddTransient<ITodoService, TodoService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
