using MediatR;
using Sieve.Models;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class GetBouquetsRequest : IRequest<GetBouquetsResponse>
    {
        public SieveModel SieveModel { get; init; }
    }
}