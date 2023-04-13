using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    public class RemoveDecorationRequest : IRequest<RemoveDecorationResponse>
    {
        public int DecorationId { get; init; }
    }
}