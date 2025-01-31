using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class UpdateUserAddressRequest : IRequest<UpdateUserAddressResponse>
{
    public required string Email { get; set; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Street { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }

}