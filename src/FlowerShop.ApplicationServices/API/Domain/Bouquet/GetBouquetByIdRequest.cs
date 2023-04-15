using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    public class GetBouquetByIdRequest : IRequest<GetBouquetByIdResponse>
    {
        public int BouquetId { get; set; }
    }
}
