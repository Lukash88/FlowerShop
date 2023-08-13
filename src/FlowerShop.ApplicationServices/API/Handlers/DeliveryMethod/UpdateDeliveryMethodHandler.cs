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
    public class UpdateDeliveryMethodHandler : IRequestHandler<UpdateDeliveryMethodRequest, UpdateDeliveryMethodResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateDeliveryMethodHandler(IMapper mapper, IQueryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<UpdateDeliveryMethodResponse> Handle(UpdateDeliveryMethodRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveryMethodQuery()
            {
                Id = request.MethodId
            };
            var getDeliveryMethod = await this.queryExecutor.Execute(query);
            if (getDeliveryMethod is null)
            {
                return new UpdateDeliveryMethodResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDeliveryMethod = this.mapper.Map<DataAccess.Core.Entities.OrderAggregate.DeliveryMethod>(request);
            var command = new UpdateDeliveryMethodCommand()
            {
                Parameter = mappedDeliveryMethod
            };
            var updatedDeliveryMethod = await this.commandExecutor.Execute(command);
            var response = new UpdateDeliveryMethodResponse()
            {
                Data = this.mapper.Map<DeliveryMethodDto>(updatedDeliveryMethod)
            };

            return response;
        }
    }
}