namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public sealed class ShippingAddress
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}