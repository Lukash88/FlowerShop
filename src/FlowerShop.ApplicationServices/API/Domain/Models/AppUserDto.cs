using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class AppUserDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public Gender? Gender { get; init; }
    public required string Email { get; init; }
    public AddressDto? Address { get; init; }
}