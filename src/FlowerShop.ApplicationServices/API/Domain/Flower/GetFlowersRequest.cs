using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Flower;

public class GetFlowersRequest : IRequest<GetFlowersResponse>
{
    public required SieveModel SieveModel { get; init; }
}