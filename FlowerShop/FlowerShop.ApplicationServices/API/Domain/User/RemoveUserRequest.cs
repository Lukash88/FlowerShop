using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public int UserId { get; set; }
    }
}