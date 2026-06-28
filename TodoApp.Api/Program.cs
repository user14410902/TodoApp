using Microsoft.EntityFrameworkCore;
using Repository;
using FastEndpoints.AspVersioning;
using FastEndpoints.Security; //add this


using Asp.Versioning;
using Asp.Versioning.Conventions;
using Asp.Versioning.ApiExplorer;

VersionSets.CreateApi(">>Todos<<", v => v
    .HasApiVersion(1.0));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthenticationJwtBearer(s => s.SigningKey = "The secret used to sign tokens. Which must be at least 256 bits. Even longer");
builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddProblemDetails();
// builder.Services.AddApiVersioning(options=>
// {
//     options.Api
// });
builder.Services.AddVersioning(options =>
{
    options.DefaultApiVersion = new(1.0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerDocument(options =>
{
    options.DocumentSettings = x =>
    {
        x.DocumentName = "Version 1";
        x.ApiVersion(new(1.0));
    };
    options.AutoTagPathSegmentIndex = 0;
});
builder.Services.AddDbContextFactory<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnectionString"));

});

builder.Services.AddOpenApiDocument(options =>
{
    options.DocumentName = "Release 1";
    options.ApiVersion(new(1.0));
});

var app = builder.Build();
app.UseAuthentication(); //add this
app.UseAuthorization();//add this
app.UseFastEndpoints(options =>
{
    options.Versioning.Prefix = "v";
});
app.UseSwaggerGen();

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
