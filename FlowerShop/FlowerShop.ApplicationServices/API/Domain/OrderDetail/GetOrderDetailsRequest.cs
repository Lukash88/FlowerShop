namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using MediatR;

    public class GetOrderDetailsRequest : IRequest<GetOrderDetailsResponse>
    {
        public string Name { get; set; }
    }
}