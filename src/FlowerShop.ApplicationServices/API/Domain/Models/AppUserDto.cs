using FlowerShop.DataAccess.Core.Enums;
using System;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class AppUserDto
    {
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public AddressDto? Address { get; set; }
    }
}