using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    public class RemoveFlowerRequest : IRequest<RemoveFlowerResponse>
    {
        public int FlowerId { get; init; }
    }
}