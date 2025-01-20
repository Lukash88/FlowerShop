using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;

public class GetDeliveryMethodByIdRequest : IRequest<GetDeliveryMethodByIdResponse>
{
    public required int MethodId;
}