using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();
builder.Services.AddDbContextFactory<TodoDbContext>(options =>
options.UseInMemoryDatabase("TodoInMemoryDb"));

var app = builder.Build();

app.UseFastEndpoints();

app.StartSeed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); //e.g. http://localhost:5285/openapi/v1.json
}

app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseFileServer();



app.Run();
