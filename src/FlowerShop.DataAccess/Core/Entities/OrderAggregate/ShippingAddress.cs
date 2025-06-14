namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public sealed class ShippingAddress
{
    public required string Name { get; init; }
    public required string Line1 { get; init; }
    public string? Line2 { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string PostalCode { get; init; }
    public required string Country { get; init; }
    
}