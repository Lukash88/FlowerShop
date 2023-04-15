using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    public class GetDecorationByIdRequest : IRequest<GetDecorationByIdResponse>
    {
        public int DecorationId { get; init; }
    }
}