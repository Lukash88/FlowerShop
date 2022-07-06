namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    using MediatR;
    using Sieve.Models;

    public class GetOrdersRequest : IRequest<GetOrdersResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}