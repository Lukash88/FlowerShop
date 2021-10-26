namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using MediatR;

    public class RemoveBouquetRequest : IRequest<RemoveBouquetResponse>
    {
        public int BouquetId { get; init; }
    }
}
