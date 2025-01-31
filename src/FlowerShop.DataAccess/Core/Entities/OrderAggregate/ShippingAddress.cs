namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate;

public sealed class ShippingAddress
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Street { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }
}