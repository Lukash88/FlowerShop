using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    public class GetOrderDetailsRequest : IRequest<GetOrderDetailsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}