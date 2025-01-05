using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace FlowerShop.DataAccess.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var usersData = File.ReadAllText("..//FlowerShop.DataAccess/Identity/users.json");
                var users = JsonSerializer.Deserialize<List<AppUser>>(usersData);
                var password = "Pa$$w0rd";

                foreach (var user in users)
                {
                    var addUserResult = await userManager.CreateAsync(user, password);

                    if (!addUserResult.Succeeded) {
                        Console.WriteLine("Error");
                    }
                }
            }
        }
    }
}