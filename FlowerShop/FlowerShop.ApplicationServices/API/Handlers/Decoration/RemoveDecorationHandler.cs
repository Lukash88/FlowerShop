namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Decoration;
    using MediatR;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var command = new RemoveDecorationCommand()
            {
                Id = request.DecorationId
            };
            var decoration = await this.commandExecutor.Execute(command);
            var mappedDecoration = this.mapper.Map<Domain.Models.Decoration>(decoration);
            var response = new RemoveDecorationResponse()
            {
                Data = mappedDecoration
            };

            return response;
        }
    }
}
