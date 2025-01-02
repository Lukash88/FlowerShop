using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class AddDecorationHandler : IRequestHandler<AddDecorationRequest, AddDecorationResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddDecorationHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddDecorationResponse> Handle(AddDecorationRequest request, CancellationToken cancellationToken)
        {
            var decoration = _mapper.Map<DataAccess.Core.Entities.Decoration>(request);
            var command = new AddDecorationCommand() 
            { 
                Parameter = decoration 
            };
            var addedDecoration = await _commandExecutor.Execute(command);
            var response = new AddDecorationResponse()
            {
                Data = _mapper.Map<DecorationDto>(addedDecoration)
            };

            return response;
        }
    }
}