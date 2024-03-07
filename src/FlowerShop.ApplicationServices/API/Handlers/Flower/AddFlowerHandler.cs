using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Flower;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    public class AddFlowerHandler : IRequestHandler<AddFlowerRequest, AddFlowerResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddFlowerHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddFlowerResponse> Handle(AddFlowerRequest request, CancellationToken cancellationToken)
        {
            var flower = _mapper.Map<DataAccess.Core.Entities.Flower>(request);
            var command = new AddFlowerCommand() 
            { 
                Parameter = flower 
            };
            var addedFlower = await _commandExecutor.Execute(command);
            var response =  new AddFlowerResponse()
            {
                Data = _mapper.Map<Domain.Models.FlowerDto>(addedFlower)
            };

            return response;
        }
    }
}