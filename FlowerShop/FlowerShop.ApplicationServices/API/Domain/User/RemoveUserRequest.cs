namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using MediatR;

    public class RemoveUserRequest : IRequest<RemoveUserResponse>
    {
        public int UserId { get; init; }
    }
}