using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class CheckEmailExistsRequest : IRequest<CheckEmailExistsResponse>
    {
        public string EmailToCheck { get; init; }

        public CheckEmailExistsRequest()
        {
            
        }

        public CheckEmailExistsRequest(string email)
        {
            EmailToCheck = email;
        }
    }
}