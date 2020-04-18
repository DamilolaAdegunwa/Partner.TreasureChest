using FastConnect.Tool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FastConnect.Tool
{
    public class FastConnectDbContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }

        private IConfiguration configuration;

        public FastConnectDbContext()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"));
        }
    }
}
