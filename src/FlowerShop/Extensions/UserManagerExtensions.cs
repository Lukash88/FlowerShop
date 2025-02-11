﻿using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FlowerShop.API.Extensions;

internal static class UserManagerExtensions
{
    internal static async Task<AppUser?> FindUserByClaimsPrincipalWithAddress(this UserManager<AppUser> userManager,
        ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);

        return await userManager.Users.Include(x => x.Address)
            .SingleOrDefaultAsync(x => x.Email == email);
    }

    internal static async Task<AppUser?> FindUserByEmailPrincipal(this UserManager<AppUser> userManager,
        ClaimsPrincipal user) =>
        await userManager.Users
            .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
}
