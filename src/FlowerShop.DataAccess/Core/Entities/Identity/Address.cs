namespace FlowerShop.DataAccess.Core.Entities.Identity;

public class Address
{
    public int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Street { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }

    public required string AppUserId { get; init; }
    public required AppUser AppUser { get; init; }
}