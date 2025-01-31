namespace FlowerShop.ApplicationServices.API.Domain.Models;

public class AddressDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Street { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }
}