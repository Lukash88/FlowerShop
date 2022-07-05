namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using MediatR;
    using Sieve.Models;

    public class GetBouquetsRequest : IRequest<GetBouquetsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}