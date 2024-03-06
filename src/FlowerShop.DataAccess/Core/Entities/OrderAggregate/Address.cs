namespace FlowerShop.DataAccess.Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, 
            string street, string postalCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            PostalCode = postalCode;
            City = city;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}