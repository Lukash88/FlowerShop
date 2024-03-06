using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.DeliveryMethod;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class RemoveDeliveryMethodHandler : IRequestHandler<RemoveDeliveryMethodRequest, RemoveDeliveryMethodResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDeliveryMethodHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDeliveryMethodResponse> Handle(RemoveDeliveryMethodRequest request, 
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveryMethodQuery()
            {
                Id = request.MethodId
            };
            var getDeliveryMethod = await this.queryExecutor.Execute(query);
            if (getDeliveryMethod is null)
            {
                return new RemoveDeliveryMethodResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDeliveryMethod = mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
            var command = new RemoveDeliveryMethodCommand()
            {
                Parameter = mappedDeliveryMethod
            };
            var removedDeliveryMethod = await this.commandExecutor.Execute(command);
            var response = new RemoveDeliveryMethodResponse()
            {
                Data = this.mapper.Map<DeliveryMethodDto>(removedDeliveryMethod)
            };

            return response;
        }
    }
}