using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class GetCurrentUserRequest : IRequest<GetCurrentUserResponse>
    {
        public string CurrentUserName { get; set; }
        public string CurrentUserEmail { get; set; }
    }
}
