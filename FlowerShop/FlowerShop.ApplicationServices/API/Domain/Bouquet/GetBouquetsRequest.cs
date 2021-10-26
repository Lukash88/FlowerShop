namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class GetBouquetsRequest : IRequest<GetBouquetsResponse>
    {
        public Occassion Occasion { get; init; }
    }
}
