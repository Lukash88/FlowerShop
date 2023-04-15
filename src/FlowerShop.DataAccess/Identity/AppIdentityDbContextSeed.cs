using System.Linq;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace FlowerShop.DataAccess.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Susan",
                    Email = "susan@test.com",
                    UserName = "susan@test.com",
                    Address = new Address
                    {
                        FirstName = "Susan",
                        LastName = "Henderson",
                        Street = "10th Ave",
                        City = "New York",
                        PostalCode = "90210"
                    }
                };

                var user2 = new AppUser
                {
                    DisplayName = "Tom",
                    Email = "tom@test.com",
                    UserName = "tom@test.com",
                    Address = new Address
                    {
                        FirstName = "Tom",
                        LastName = "Rider",
                        Street = "Wall Street 991",
                        City = "New York",
                        PostalCode = "90210"
                    }
                };

                var password = "Pa$$w0rd";

                await userManager.CreateAsync(user, password);
                await userManager.CreateAsync(user2, password);
            }
        }
    }
}