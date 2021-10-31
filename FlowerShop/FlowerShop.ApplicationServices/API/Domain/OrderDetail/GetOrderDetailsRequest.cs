namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;

    public class GetOrderDetailsRequest : IRequest<GetOrderDetailsResponse>
    {
        public int OrderDetailId;
    }
}
