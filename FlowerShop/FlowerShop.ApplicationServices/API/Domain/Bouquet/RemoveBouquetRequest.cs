using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class RemoveBouquetRequest : IRequest<RemoveBouquetResponse>
    {
        public int BouquetId { get; set; }
    }
}