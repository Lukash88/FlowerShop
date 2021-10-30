namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;

    public class GetOrderDetailByIdRequest : IRequest<GetOrderDetailByIdResponse>
    {
        public int OrderDetailId { get; set; }
    }
}
