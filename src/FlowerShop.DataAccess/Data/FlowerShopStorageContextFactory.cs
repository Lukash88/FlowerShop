using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FlowerShop.DataAccess.Data
{
    public sealed class FlowerShopStorageContextFactory : IDesignTimeDbContextFactory<FlowerShopStorageContext>
    {
        private readonly IConfiguration _config;

        public FlowerShopStorageContextFactory(IConfiguration config)
        {
            _config = config;
        }

        public FlowerShopStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlowerShopStorageContext>();
            optionsBuilder.UseSqlServer(_config.GetConnectionString("FlowerShopDatabaseConnection"));
                                           
            return new FlowerShopStorageContext(optionsBuilder.Options);
        }
    }
}