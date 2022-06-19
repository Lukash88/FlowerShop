namespace FlowerShop.ApplicationServices.API.Domain.User
{
    using MediatR;

    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public string UserName { get; set; }
    }
}