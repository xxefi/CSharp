using System.Data.Common;
using KinoPoiskWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KinoPoiskWork.Context;

public class MovieDbContext : DbContext
{
    public MovieDbContext()
    {
        
    }
    
    public DbSet<MovieModel> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(builder.GetConnectionString("Default"));
        }
    }
}