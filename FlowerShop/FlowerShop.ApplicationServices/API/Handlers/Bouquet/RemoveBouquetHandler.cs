namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
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
            var command = new RemoveBouquetCommand()
            {
               Id = request.BouquetId
            };

            var bouquet = await this.commandExecutor.Execute(command);
            var mappedBouquet = this.mapper.Map<Domain.Models.Bouquet>(bouquet);
            var response = new RemoveBouquetResponse()
            {
                Data = mappedBouquet
            };

            return response;
        }
    }
}