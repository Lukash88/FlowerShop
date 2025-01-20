using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;

public class GetDeliveryMethodsRequest : IRequest<GetDeliveryMethodsResponse>
{
    public required SieveModel SieveModel { get; init; }
}