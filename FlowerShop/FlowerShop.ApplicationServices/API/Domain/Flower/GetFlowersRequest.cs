namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using MediatR;
    using Sieve.Models;

    public class GetFlowersRequest : IRequest<GetFlowersResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}