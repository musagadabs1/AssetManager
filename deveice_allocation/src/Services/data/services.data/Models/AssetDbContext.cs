using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace services.data.Models
{
    public class AssetDbContext:IdentityDbContext
    {
        public AssetDbContext()
        {

        }
        public AssetDbContext(DbContextOptions<AssetDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);
                var configuration=builder.Build();
                var connString = configuration.GetConnectionString("AssetDbConnection");
                optionsBuilder.UseSqlServer(connString);


            }
        }
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Asset> assets { get; set; }
        public virtual DbSet<Department> departments { get; set; }
        public virtual DbSet<AssetSummary> assetsummaries { get; set; }
    }
}
