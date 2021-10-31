namespace FlowerShop.ApplicationServices.API.Handlers.OrderDetail
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.OrderDetail;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveOrderDetailHandler : IRequestHandler<RemoveOrderDetailRequest, RemoveOrderDetailResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveOrderDetailHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<RemoveOrderDetailResponse> Handle(RemoveOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = mapper.Map<OrderDetail>(request);
            var command = new RemoveOrderDetailCommand()
            {
                Parameter = orderDetail
            };
            await this.commandExecutor.Execute(command);
            var response = new RemoveOrderDetailResponse()
            {
                Data = null
            };

            return response;
        }
    }
}
