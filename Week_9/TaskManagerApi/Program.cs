using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data;
using TaskManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("TaskManagerDatabase")
    ?? throw new InvalidOperationException(
        "Connection string 'TaskManagerDatabase' was not found.");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<TaskService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
