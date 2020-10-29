using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ASPNET.CORE.WEB.APP.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext() { }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public virtual DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
