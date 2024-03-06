using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlowerShop.DataAccess.Data
{
    public class FlowerShopStorageContextFactory : IDesignTimeDbContextFactory<FlowerShopStorageContext>
    {
        public FlowerShopStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlowerShopStorageContext>();
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = FlowerShopStorage; Integrated Security = True");
                                           
            return new FlowerShopStorageContext(optionsBuilder.Options);
        }
    }
}
