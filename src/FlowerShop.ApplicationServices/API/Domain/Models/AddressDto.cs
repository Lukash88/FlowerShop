namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class AddressDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Street { get; init; }
        public string PostalCode { get; init; }
        public string City { get; init; }
    }
}