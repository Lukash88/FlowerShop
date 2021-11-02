namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Flower;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveFlowerHandler : IRequestHandler<RemoveFlowerRequest, RemoveFlowerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveFlowerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveFlowerResponse> Handle(RemoveFlowerRequest request, CancellationToken cancellationToken)
        {
           var flower = mapper.Map<Flower>(request);
           var command = new RemoveFlowerCommand()
            {
                Parameter = flower                
            };
           await this.commandExecutor.Execute(command);
            var response = new RemoveFlowerResponse()
            {
                Data = null
            };

            return response;
        }
    }
}