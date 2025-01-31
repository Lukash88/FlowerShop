using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FlowerShop.DataAccess.Data;

public sealed class FlowerShopStorageContextFactory(IConfiguration config)
    : IDesignTimeDbContextFactory<FlowerShopStorageContext>
{
    public FlowerShopStorageContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FlowerShopStorageContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("FlowerShopDatabaseConnection"));
        return new FlowerShopStorageContext(optionsBuilder.Options);
    }
}