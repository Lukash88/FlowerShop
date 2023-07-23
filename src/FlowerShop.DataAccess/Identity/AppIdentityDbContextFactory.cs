using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FlowerShop.DataAccess.Identity
{
    public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();

            var connectionString = configuration.GetConnectionString("IdentityDatabaseConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}