using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}