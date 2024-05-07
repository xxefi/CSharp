using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MinAPI.Data.DbContext;
using MinAPI.Data.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BikeStoreContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

app.MapGet("getbrands", (BikeStoreContext storeContext) =>
    {
        var products = storeContext.Products;
        return products;
    })
.WithName("GetBrands")
.WithOpenApi();

app.MapPost("addbrands", async (BikeStoreContext storeContext, HttpRequest request) =>
{
    var headers = request.Headers;
    try
    {
        var brandName = headers.First(x => x.Key.ToLower() == "brand");
        var brand = new Brand()
        {
            BrandName = brandName.Value
        };
        await storeContext.Brands.AddAsync(brand);
        await storeContext.SaveChangesAsync();
        return new
        {
            Result = "Brand added succesful",
            Code = 200
        };
    }
    catch (Exception ex)
    {
        return new
        {
            Result = ex.Message,
            Code = 500
        };
    }
})
.WithName("AddBrand")
.WithOpenApi();

app.MapDelete("removebrand", async (BikeStoreContext storeContext, HttpRequest request) =>
{
    var headers = request.Headers;
    try
    {
        var brandName = request.Headers["brand"].FirstOrDefault();
        if (brandName == null)
        {
            return new
            {
                Result = "Brand name not provided",
                Code = 400
            };
        }

        var brand = await storeContext.Brands.FirstOrDefaultAsync(b => b.BrandName == brandName);
        if (brand == null)
        {
            return new
            {
                Result = "Brand not found",
                Code = 404
            };
            
        }
        storeContext.Brands.Remove(brand);
        await storeContext.SaveChangesAsync();
        return new
        {
            Result = "Brand removed succesful",
            Code = 200,
        };
    }
    catch (Exception ex)
    {
        return new
        {
            Result = ex.Message,
            Code = 500
        };
    }
})
.WithName("RemoveBrand")
.WithOpenApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.Run();