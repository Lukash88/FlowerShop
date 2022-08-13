namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AddBouquetHandler : IRequestHandler<AddBouquetRequest, AddBouquetResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddBouquetHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddBouquetResponse> Handle(AddBouquetRequest request, CancellationToken cancellationToken)
        {
            var flowersQuery = new GetFlowersQuery();
            var getFlowers = await this.queryExecutor.ExecuteWithSieve(flowersQuery);
            var chosenFlowers = getFlowers.Where(x => request.FlowersIds.Contains(x.Id)).ToList();

            var bouquet = this.mapper.Map<Bouquet>(request);
            bouquet.Flowers.AddRange(chosenFlowers);
            var command = new AddBouquetCommand() 
            { 
                Parameter = bouquet 
            };
            var addedBouquet = await this.commandExecutor.Execute(command);
            var response = new AddBouquetResponse()
            {
                Data = this.mapper.Map<Domain.Models.BouquetDTO>(addedBouquet)
            };

            return response;
        }
    }
}