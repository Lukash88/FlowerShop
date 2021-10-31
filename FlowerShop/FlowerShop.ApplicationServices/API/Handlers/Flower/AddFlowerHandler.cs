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


    public class AddFlowerHandler : IRequestHandler<AddFlowerRequest, AddFlowerResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddFlowerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddFlowerResponse> Handle(AddFlowerRequest request, CancellationToken cancellationToken)
        {
            var flower = this.mapper.Map<Flower>(request);
            var command = new AddFlowerCommand() { Parameter = flower };
            var flowerFromDb = await this.commandExecutor.Execute(command);

            return new AddFlowerResponse()
            {
                Data = this.mapper.Map<Domain.Models.FlowerDTO>(flowerFromDb)
            };
        }
    }
}
