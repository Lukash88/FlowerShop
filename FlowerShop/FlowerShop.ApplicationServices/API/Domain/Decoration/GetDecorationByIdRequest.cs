namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using MediatR;

    public class GetDecorationByIdRequest : IRequest<GetDecorationByIdResponse>
    {
        public int DecorationId { get; init; }
    }
}