namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.User;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);

            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDTO>(userFromDb)
            };
        }
    }
}
