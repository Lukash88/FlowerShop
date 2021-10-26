namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using MediatR;

    public class GetBouquetByIdRequest : IRequest<GetBouquetByIdResponse>
    {
        public int BouquetId { get; init; }
    }
}
