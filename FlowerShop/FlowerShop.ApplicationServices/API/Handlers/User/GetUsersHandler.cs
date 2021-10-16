using FlowerShop.ApplicationServices.API.Domain.User;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;

        public GetUsersHandler(IRepository<DataAccess.Entities.User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = this.userRepository.GetAll();
            var domainUsers = users.Select(x => new Domain.Models.User()
            {
                Id = x.Id,
                Roles = x.Roles,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                UserName = x.UserName,
                City = x.City
                });

            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
