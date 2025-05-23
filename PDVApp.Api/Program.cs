using Microsoft.EntityFrameworkCore;

using PDVApp.Api.Context;
using PDVApp.Api.Repository;
using PDVApp.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context service DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

//AutoMapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Services Injection
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
////builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IProductService, ProductService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
