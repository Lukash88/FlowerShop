using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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


            // optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("IdentityDatabaseConnection"));
            //optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = IdentityFlowerShop; Integrated Security = True");
            // optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("IdentityDatabaseConnection"));

            return new AppIdentityDbContext(optionsBuilder.Options);
        }
    }
}