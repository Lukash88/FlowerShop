using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class GetFlowersRequest : IRequest<GetFlowersResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}