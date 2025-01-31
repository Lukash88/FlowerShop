namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class UserDto
{
    public required string Email { get; init; } 
    public required string DisplayName { get; init; }
    public required string Token { get; set; }
}