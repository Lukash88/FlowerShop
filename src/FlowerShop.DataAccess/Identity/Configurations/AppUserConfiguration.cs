﻿using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Identity.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .Property(x => x.UserName)
            .HasMaxLength(50);

        builder
            .Property(x => x.DisplayName)
            .IsRequired()
            .HasMaxLength(50);
    }
}