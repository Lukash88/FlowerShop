using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class UpdateDecorationHandler : IRequestHandler<UpdateDecorationRequest, UpdateDecorationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateDecorationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async  Task<UpdateDecorationResponse> Handle(UpdateDecorationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationQuery()
            {
                Id = request.DecorationId
            };
            var getDecoration = await _queryExecutor.Execute(query);
            if (getDecoration is null)
            {
                return new UpdateDecorationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDecoration = _mapper.Map<DataAccess.Core.Entities.Decoration>(request);
            var command = new UpdateDecorationCommand()
            {
                Parameter = mappedDecoration
            };
            var updatedDecoration = await _commandExecutor.Execute(command);
            var response = new UpdateDecorationResponse()
            {
                Data = _mapper.Map<DecorationDto>(updatedDecoration)
            };

            return response;
        }
    }
}