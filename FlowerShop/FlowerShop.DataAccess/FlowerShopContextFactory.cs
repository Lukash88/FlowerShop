using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DataAccess
{
    public class FlowerShopContextFactory : IDesignTimeDbContextFactory<FlowerShopContext>
    {
        public FlowerShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FlowerShopContext>();
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = FlowerShop; Integrated Security = True");
            return new FlowerShopContext(optionsBuilder.Options);
        }
    }
}
