namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;
    using Sieve.Models;

    public class GetOrderDetailsRequest : IRequest<GetOrderDetailsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}