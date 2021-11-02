namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.User;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = user
            };
            var userFromDb = await this.commandExecutor.Execute(command);

            return new UpdateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.UserDTO>(userFromDb)
            };
        }
    }
}
