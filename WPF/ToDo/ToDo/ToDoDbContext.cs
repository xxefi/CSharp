using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDo.Models;

namespace ToDo
{
    public class ToDoDbContext : DbContext
    {


        public ToDoDbContext()
        {

        }

        public DbSet<ToDoModel> ToDo { get; set; }

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
}
