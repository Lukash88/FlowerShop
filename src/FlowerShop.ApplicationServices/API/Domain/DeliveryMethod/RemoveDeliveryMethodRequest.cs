using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod
{
    public class RemoveDeliveryMethodRequest : IRequest<RemoveDeliveryMethodResponse>
    {
        public int MethodId;
    }
}