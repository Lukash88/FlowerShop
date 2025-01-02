using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class RemoveBouquetHandler : IRequestHandler<RemoveBouquetRequest, RemoveBouquetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public RemoveBouquetHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<RemoveBouquetResponse> Handle(RemoveBouquetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetQuery()
            {
                Id = request.BouquetId
            };
            var getBouquet = await _queryExecutor.Execute(query);
            if (getBouquet is null)
            {
                return new RemoveBouquetResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBouquet = _mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
            var command = new RemoveBouquetCommand()
            {
               Parameter = mappedBouquet
            };
            var removedBouquet = await _commandExecutor.Execute(command);
            var response = new RemoveBouquetResponse()
            {
                Data = _mapper.Map<BouquetDto>(removedBouquet)
            };

            return response;
        }
    }
}