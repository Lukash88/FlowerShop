﻿using FlowerShop.DataAccess.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace FlowerShop.DataAccess.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public Address Address { get; set; }
    }
}