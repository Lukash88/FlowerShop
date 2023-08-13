using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    public class GetOrdersForUserRequest : IRequest<GetOrdersResponse>
    {
        public string Email { get; set; }
        public SieveModel SieveModel { get; init; }
    }
}