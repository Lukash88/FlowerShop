namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using MediatR;

    public class GetDecorationsRequest : IRequest<GetDecorationsResponse>
    {
        public string Name { get; set; }
    }
}
