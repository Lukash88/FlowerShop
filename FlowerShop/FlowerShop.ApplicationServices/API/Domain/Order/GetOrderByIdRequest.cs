namespace FlowerShop.ApplicationServices.API.Domain.Order
{
    using MediatR;

    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public int OrderId;
    }
}