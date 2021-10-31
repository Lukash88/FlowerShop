namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveBouquetHandler : IRequestHandler<RemoveBouquetRequest, RemoveBouquetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveBouquetHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<RemoveBouquetResponse> Handle(RemoveBouquetRequest request, CancellationToken cancellationToken)
        {
            var bouquet = mapper.Map<Bouquet>(request);
            var command = new RemoveBouquetCommand()
            {
               Parameter = bouquet
            };
            await this.commandExecutor.Execute(command);
            var response = new RemoveBouquetResponse()
            {
                Data = null
            };

            return response;
        }
    }
}