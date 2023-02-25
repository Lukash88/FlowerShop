namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Flower;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveFlowerHandler : IRequestHandler<RemoveFlowerRequest, RemoveFlowerResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveFlowerHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveFlowerResponse> Handle(RemoveFlowerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetFlowerQuery()
            {
                Id = request.FlowerId
            };
            var getFlower = await this.queryExecutor.Execute(query);
            if (getFlower == null)
            {
                return new RemoveFlowerResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedFlower = mapper.Map<DataAccess.Core.Entities.Flower>(request);
            var command = new RemoveFlowerCommand()
             {
                 Parameter = mappedFlower                
            };
            var removedFlower = await this.commandExecutor.Execute(command);
            var response = new RemoveFlowerResponse()
            {
                Data = this.mapper.Map<Domain.Models.FlowerDTO>(removedFlower)
            };

            return response;
        }
    }
}