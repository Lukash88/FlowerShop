namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Flower;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateFlowerHandler : IRequestHandler<UpdateFlowerRequest, UpdateFlowerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateFlowerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateFlowerResponse> Handle(UpdateFlowerRequest request, CancellationToken cancellationToken)
        {
            var flower = this.mapper.Map<DataAccess.Entities.Flower>(request);
            var command = new UpdateFlowerCommand()
            {
                Parameter = flower
            };
            var flowerFromDb = await this.commandExecutor.Execute(command);

            return  new UpdateFlowerResponse()
            {
                Data = this.mapper.Map<Domain.Models.FlowerDTO>(flowerFromDb)
            };           
        }
    }
}
