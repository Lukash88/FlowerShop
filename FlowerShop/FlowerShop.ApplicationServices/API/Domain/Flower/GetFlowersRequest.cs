namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using MediatR;

    public class GetFlowersRequest : IRequest<GetFlowersResponse>
    {
        public string Name { get; init; }
    }
}
