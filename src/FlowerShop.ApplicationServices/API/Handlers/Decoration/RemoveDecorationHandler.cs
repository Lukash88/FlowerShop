using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class RemoveDecorationHandler : IRequestHandler<RemoveDecorationRequest, RemoveDecorationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public RemoveDecorationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<RemoveDecorationResponse> Handle(RemoveDecorationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationQuery()
            {
                Id = request.DecorationId
            };
            var getDecoration = await _queryExecutor.Execute(query);
            if (getDecoration is null)
            {
                return new RemoveDecorationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDecoration = _mapper.Map<DataAccess.Core.Entities.Decoration>(request);
            var command = new RemoveDecorationCommand()
            {
                Parameter = mappedDecoration
            };
            var removedBouquet = await _commandExecutor.Execute(command);            
            var response = new RemoveDecorationResponse()
            {
                Data = _mapper.Map<Domain.Models.DecorationDto>(removedBouquet)
            };

            return response;
        }
    }
}