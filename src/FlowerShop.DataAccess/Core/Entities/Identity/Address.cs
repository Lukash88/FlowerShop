namespace FlowerShop.DataAccess.Core.Entities.Identity;

public class Address
{
public int Id { get; init; }
public required string Line1 { get; init; }
public string? Line2 { get; init; }
public required string City { get; init; }
public required string State { get; init; }
public required string PostalCode { get; init; }
public required string Country { get; init; }

public required string AppUserId { get; init; }
public required AppUser AppUser { get; init; }
}