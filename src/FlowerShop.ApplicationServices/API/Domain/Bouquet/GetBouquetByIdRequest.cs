using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet;

public class GetBouquetByIdRequest : IRequest<GetBouquetByIdResponse>
{
    public required int BouquetId { get; init; }
}