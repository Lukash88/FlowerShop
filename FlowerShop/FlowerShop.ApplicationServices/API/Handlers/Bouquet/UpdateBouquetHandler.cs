namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateBouquetHandler : IRequestHandler<UpdateBouquetRequest, UpdateBouquetResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateBouquetHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<UpdateBouquetResponse> Handle(UpdateBouquetRequest request, CancellationToken cancellationToken)
        {
            var bouquet = this.mapper.Map<DataAccess.Entities.Bouquet>(request);
            var command = new UpdateBouquetCommand()
            {
                Parameter = bouquet
            };
            var bouquetFromDb = await this.commandExecutor.Execute(command);

            return new UpdateBouquetResponse()
            {
                Data = this.mapper.Map<Domain.Models.BouquetDTO>(bouquetFromDb)
            };
        }
    }
}
