using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
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
            var decoration = this.mapper.Map<DataAccess.Core.Entities.Decoration>(request);
            var command = new AddDecorationCommand() 
            { 
                Parameter = decoration 
            };
            var addedDecoration = await this.commandExecutor.Execute(command);
            var response = new AddDecorationResponse()
            {
                Data = this.mapper.Map<DecorationDto>(addedDecoration)
            };

            return response;
        }
    }
}