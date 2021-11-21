namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using MediatR;

    public class RemoveDecorationRequest : IRequest<RemoveDecorationResponse>
    {
        public int DecorationId { get; init; }
    }
}