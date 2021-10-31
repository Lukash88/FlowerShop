namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Decoration;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveDecorationHandler : IRequestHandler<RemoveDecorationRequest, RemoveDecorationResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDecorationHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDecorationResponse> Handle(RemoveDecorationRequest request, CancellationToken cancellationToken)
        {
            var decoration = mapper.Map<Decoration>(request);
            var command = new RemoveDecorationCommand()
            {
                Parameter = decoration
            };
            await this.commandExecutor.Execute(command);            
            var response = new RemoveDecorationResponse()
            {
                Data = null
            };

            return response;
        }
    }
}
