using Microsoft.EntityFrameworkCore;
using TodoApi.DBContext;
using TodoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add user secrets if in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddDbContext<AppDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
