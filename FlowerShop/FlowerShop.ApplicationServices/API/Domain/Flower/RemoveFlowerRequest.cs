namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using MediatR;

    public class RemoveFlowerRequest : IRequest<RemoveFlowerResponse>
    {
        public int FlowerId { get; init; }
    }
}