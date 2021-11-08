namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Decoration;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateDecorationHandler : IRequestHandler<UpdateDecorationRequest, UpdateDecorationResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public UpdateDecorationHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async  Task<UpdateDecorationResponse> Handle(UpdateDecorationRequest request, CancellationToken cancellationToken)
        {
            var decoration = this.mapper.Map<DataAccess.Entities.Decoration>(request);
            var command = new UpdateDecorationCommand()
            {
                Parameter = decoration
            };

            if (decoration == null)
            {
                return new UpdateDecorationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var decorationFromDb = await this.commandExecutor.Execute(command);
            return new UpdateDecorationResponse()
            {
                Data = this.mapper.Map<Domain.Models.DecorationDTO>(decorationFromDb)
            };
        }
    }
}

