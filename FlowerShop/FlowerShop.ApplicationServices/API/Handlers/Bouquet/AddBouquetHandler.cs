namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using FlowerShop.DataAccess.CQRS.Commands.BouquetFlower;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System;
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
            // retrieving list of flowers
            var getFlowers = await this.queryExecutor.ExecuteWithSieve(flowersQuery);
            // retrieving list of chosen flowers and their IDs in form of List<Tuple<int, int>
            var flowersIdAndQuantity = request.FlowersIdAndQuandity;
            // list of flowers IDs
            var flowersId = flowersIdAndQuantity.Select(x => x.Item1);
            // retrieving list of chosen flowers based on their IDs
            var chosenFlowers = getFlowers.Where(x => flowersId.Contains(x.Id)).ToList();

            var bouquet = this.mapper.Map<Bouquet>(request);

            var bouquetFlowers = new List<BouquetFlower>();
            foreach (var flower in chosenFlowers)
            {
                bouquetFlowers.Add(new BouquetFlower
                {
                    Bouquet = bouquet,
                    FlowerId = flower.Id,
                    // retrieving of single flower quantity based on its ID from List<Tuple<int, int>
                    FlowerQuantity = flowersIdAndQuantity.Where(x => x.Item1 == flower.Id).Select(x => x.Item2).FirstOrDefault()
                });
            }

            var parameter = Tuple.Create(bouquet, bouquetFlowers);

            var command = new AddBouquetCommand()
            {
                Parameter = parameter
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