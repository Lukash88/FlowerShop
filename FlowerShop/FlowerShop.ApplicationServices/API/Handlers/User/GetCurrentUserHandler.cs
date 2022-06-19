namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.User;
    using FlowerShop.DataAccess.CQRS.Queries.User;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;

        public GetCurrentUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, 
            IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {                
                UserName = request.CurrentUserName,
                Email = request.CurrentUserEmail
            };

            var getUser = await this.queryExecutor.Execute(query);
            if (getUser == null)
            {
                return new GetCurrentUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };                
            }

            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand() 
            { 
                Parameter = user 
            };
            var addedUser = await this.commandExecutor.Execute(command);
            var response = new GetCurrentUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDTO>(addedUser)
            };

            return response;
        }
    }
}