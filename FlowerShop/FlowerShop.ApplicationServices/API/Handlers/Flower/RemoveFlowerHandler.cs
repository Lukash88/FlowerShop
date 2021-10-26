namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Flower;
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
            var command = new RemoveFlowerCommand()
            {
                Id = request.FlowerId
            };

            var flower = await this.commandExecutor.Execute(command);
            var mappedFlower = this.mapper.Map<Domain.Models.Flower>(flower);
            var response = new RemoveFlowerResponse()
            {
                Data = mappedFlower
            };

            return response;
        }
    }
}