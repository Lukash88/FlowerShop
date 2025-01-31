using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration;

public class GetDecorationByIdRequest : IRequest<GetDecorationByIdResponse>
{
    public required int DecorationId { get; init; }
}