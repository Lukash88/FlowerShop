using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User;

public class UpdateUserAddressRequest : IRequest<UpdateUserAddressResponse>
{
    public required string Email { get; set; }
    public required string Line1 { get; init; }
    public string? Line2 { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string PostalCode { get; init; }
    public required string Country { get; init; }
}