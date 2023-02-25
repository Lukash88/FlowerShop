namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveBouquetHandler : IRequestHandler<RemoveBouquetRequest, RemoveBouquetResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveBouquetHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveBouquetResponse> Handle(RemoveBouquetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetQuery()
            {
                Id = request.BouquetId
            };
            var getBouquet = await this.queryExecutor.Execute(query);
            if (getBouquet == null)
            {
                return new RemoveBouquetResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBouquet = mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
            var command = new RemoveBouquetCommand()
            {
               Parameter = mappedBouquet
            };
            var removedBouquet = await this.commandExecutor.Execute(command);
            var response = new RemoveBouquetResponse()
            {
                Data = this.mapper.Map<Domain.Models.BouquetDTO>(removedBouquet)
            };

            return response;
        }
    }
}