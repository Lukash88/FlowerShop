namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using MediatR;
    using Sieve.Models;

    public class GetDecorationsRequest : IRequest<GetDecorationsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}