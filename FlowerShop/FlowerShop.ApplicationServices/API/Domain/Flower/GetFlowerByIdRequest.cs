namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using MediatR;

    public class GetFlowerByIdRequest : IRequest<GetFlowerByIdResponse>
    {
        public int FlowerId { get; init; }
    }
}
