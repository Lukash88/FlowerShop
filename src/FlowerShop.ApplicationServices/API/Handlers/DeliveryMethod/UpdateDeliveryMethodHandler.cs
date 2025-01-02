using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class UpdateDeliveryMethodHandler : IRequestHandler<UpdateDeliveryMethodRequest, UpdateDeliveryMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateDeliveryMethodHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateDeliveryMethodResponse> Handle(UpdateDeliveryMethodRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveryMethodQuery()
            {
                Id = request.MethodId
            };
            var getDeliveryMethod = await _queryExecutor.Execute(query);
            if (getDeliveryMethod is null)
            {
                return new UpdateDeliveryMethodResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDeliveryMethod = _mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
            var command = new UpdateDeliveryMethodCommand()
            {
                Parameter = mappedDeliveryMethod
            };
            var updatedDeliveryMethod = await _commandExecutor.Execute(command);
            var response = new UpdateDeliveryMethodResponse()
            {
                Data = _mapper.Map<DeliveryMethodDto>(updatedDeliveryMethod)
            };

            return response;
        }
    }
}