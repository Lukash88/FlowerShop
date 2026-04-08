using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace FlowerShop.DataAccess.Identity;

public static class AppIdentityDbContextSeed
{
    private const string Password = "Pa$$w0rd";
    private const string UsersJsonPath = "../FlowerShop.DataAccess/Identity/users.json";

    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var usersData = await File.ReadAllTextAsync(UsersJsonPath);
            var users = JsonSerializer.Deserialize<List<AppUser>>(usersData);

            if (users is not null)
            {
                foreach (var user in users)
                {
                    var addUserResult = await userManager.CreateAsync(user, Password);
                    if (!addUserResult.Succeeded)
                    {
                        Console.WriteLine("Error");
                    }
                }
            }
        }
    }
}