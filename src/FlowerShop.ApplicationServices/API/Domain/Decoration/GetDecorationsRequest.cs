using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration;

public class GetDecorationsRequest : IRequest<GetDecorationsResponse>
{
    public required SieveModel SieveModel { get; init; }
}