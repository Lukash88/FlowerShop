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

    public class AddDecorationHandler : IRequestHandler<AddDecorationRequest, AddDecorationResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddDecorationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddDecorationResponse> Handle(AddDecorationRequest request, CancellationToken cancellationToken)
        {
            var decoration = this.mapper.Map<Decoration>(request);
            var command = new AddDecorationCommand() 
            { 
                Parameter = decoration 
            };
            var addedDecoration = await this.commandExecutor.Execute(command);
            var response = new AddDecorationResponse()
            {
                Data = this.mapper.Map<Domain.Models.DecorationDTO>(addedDecoration)
            };

            return response;
        }
    }
}