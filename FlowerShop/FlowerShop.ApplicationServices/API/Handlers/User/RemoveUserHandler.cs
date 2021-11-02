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

    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            var command = new RemoveUserCommand()
            {
                Parameter = user
            };
            await this.commandExecutor.Execute(command);
            var response = new RemoveUserResponse()
            {
                Data = null
            };

            return response;
        }
    }
}