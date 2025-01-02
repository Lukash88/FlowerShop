using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Flower;
using FlowerShop.DataAccess.CQRS.Queries.Flower;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    public class RemoveFlowerHandler : IRequestHandler<RemoveFlowerRequest, RemoveFlowerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public RemoveFlowerHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<RemoveFlowerResponse> Handle(RemoveFlowerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetFlowerQuery()
            {
                Id = request.FlowerId
            };
            var getFlower = await _queryExecutor.Execute(query);
            if (getFlower is null)
            {
                return new RemoveFlowerResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedFlower = _mapper.Map<DataAccess.Core.Entities.Flower>(request);
            var command = new RemoveFlowerCommand()
             {
                 Parameter = mappedFlower                
            };
            var removedFlower = await _commandExecutor.Execute(command);
            var response = new RemoveFlowerResponse()
            {
                Data = _mapper.Map<Domain.Models.FlowerDto>(removedFlower)
            };

            return response;
        }
    }
}