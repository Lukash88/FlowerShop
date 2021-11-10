namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Decoration;
    using FlowerShop.DataAccess.CQRS.Queries.Decoration;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveDecorationHandler : IRequestHandler<RemoveDecorationRequest, RemoveDecorationResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public RemoveDecorationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<RemoveDecorationResponse> Handle(RemoveDecorationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationQuery()
            {
                Id = request.DecorationId
            };
            var getDecoration = await this.queryExecutor.Execute(query);
            if (getDecoration == null)
            {
                return new RemoveDecorationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDecoration = mapper.Map<Decoration>(request);
            var command = new RemoveDecorationCommand()
            {
                Parameter = mappedDecoration
            };
            var removedBouquet = await this.commandExecutor.Execute(command);            
            var response = new RemoveDecorationResponse()
            {
                Data = this.mapper.Map<Domain.Models.DecorationDTO>(removedBouquet)
            };

            return response;
        }
    }
}
