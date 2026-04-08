using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace FlowerShop.DataAccess.Identity;

public static class AppIdentityDbContextSeed
{
    private const string Password = "Pa$$w0rd";
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var usersData = await File.ReadAllTextAsync("..//FlowerShop.DataAccess/Identity/users.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(usersData);
           

            if (users is not null)
                foreach (var user in users)
                {
                    var addUserResult = await userManager.CreateAsync(user, Password);
                    var addRoleToUserResult = await userManager.AddToRoleAsync(user, "Customer");

                if (!addUserResult.Succeeded || !addRoleToUserResult.Succeeded)
                    {
                        Console.WriteLine("Error");
                    }
                }
        }
    }
}