using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IRepository<User> userRepository;

        public GetUserHandler(IRepository<DataAccess.Entities.User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
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

            var response = new GetUserResponse()
            {
                Data = domainUsers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
