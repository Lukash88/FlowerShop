using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess
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
