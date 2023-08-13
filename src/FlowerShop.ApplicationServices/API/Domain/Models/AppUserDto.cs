using FlowerShop.DataAccess.Core.Enums;
using System;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class AppUserDto
    {
        public string DisplayName { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public Gender? Gender { get; init; }
        public string Email { get; init; }
        public string Token { get; set; }
        public AddressDto? Address { get; init; }
    }
}