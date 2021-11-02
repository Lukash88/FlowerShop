namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using MediatR;

    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; init; }
    }
}
