﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Decoration;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    public class UpdateDecorationHandler : IRequestHandler<UpdateDecorationRequest, UpdateDecorationResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateDecorationHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async  Task<UpdateDecorationResponse> Handle(UpdateDecorationRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationQuery()
            {
                Id = request.DecorationId
            };
            var getDecoration = await this.queryExecutor.Execute(query);
            if (getDecoration is null)
            {
                return new UpdateDecorationResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDecoration = this.mapper.Map<DataAccess.Core.Entities.Decoration>(request);
            var command = new UpdateDecorationCommand()
            {
                Parameter = mappedDecoration
            };
            var updatedDecoration = await this.commandExecutor.Execute(command);
            var response = new UpdateDecorationResponse()
            {
                Data = this.mapper.Map<DecorationDto>(updatedDecoration)
            };

            return response;
        }
    }
}