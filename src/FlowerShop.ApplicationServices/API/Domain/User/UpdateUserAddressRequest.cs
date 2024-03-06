using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class UpdateUserAddressRequest : IRequest<UpdateUserAddressResponse>
    {
        public string Email { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Street { get; init; }
        public string PostalCode { get; init; }
        public string City { get; init; }

    }
}