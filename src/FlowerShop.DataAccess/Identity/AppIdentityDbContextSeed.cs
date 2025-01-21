using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace FlowerShop.DataAccess.Identity;

public static class AppIdentityDbContextSeed
{
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var usersData = await File.ReadAllTextAsync("..//FlowerShop.DataAccess/Identity/users.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(usersData);
            const string password = "Pa$$w0rd";

            if (users is not null)
                foreach (var user in users)
                {
                    var addUserResult = await userManager.CreateAsync(user, password);

                    if (!addUserResult.Succeeded)
                    {
                        Console.WriteLine("Error");
                    }
                }
        }
    }
}