namespace FlowerShop.ApplicationServices.API.Domain.Models;

public sealed class UserInfoDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Token { get; set; }
    public AddressDto? Address { get; init; }
    public string[]? Roles { get; set; }
}