namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using MediatR;
    using Sieve.Models;

    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}