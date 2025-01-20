using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Bouquet;

public class RemoveBouquetRequest : IRequest<RemoveBouquetResponse>
{
    public required int BouquetId { get; init; }
}