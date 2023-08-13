using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod
{
    public class UpdateDeliveryMethodRequest : IRequest<UpdateDeliveryMethodResponse>
    {
        public int MethodId;
        public string ShortName { get; init; }
        public string DeliveryTime { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}