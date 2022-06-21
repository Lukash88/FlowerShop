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

    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;

        public AddUserHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, 
            IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {                
                UserName = request.UserName,
                Email = request.Email
            };

            var getUser = await this.queryExecutor.Execute(query);
            if (getUser != null)
            {
                if (getUser.UserName == request.UserName)
                {
                    return new AddUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.ValidationError + "! The name is already taken.")
                    };
                }
                if (getUser.Email == request.Email)
                {
                    return new AddUserResponse()
                    {
                        Error = new ErrorModel(ErrorType.ValidationError + "! Email address is in use.")
                    };
                }

                return new AddUserResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            request.PasswordHash = passwordHasher.HashPassword(getUser, request.Password);

            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand() 
            { 
                Parameter = user 
            };
            var addedUser = await this.commandExecutor.Execute(command);
            var response = new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDTO>(addedUser)
            };

            return response;
        }
    }
}