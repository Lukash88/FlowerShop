namespace FlowerShop.ApplicationServices.API.Domain.Models;

public sealed class UserInfoDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public AddressDto? Address { get; init; }
}