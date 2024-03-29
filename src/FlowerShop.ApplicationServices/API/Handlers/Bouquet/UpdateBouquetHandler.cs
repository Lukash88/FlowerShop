﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class UpdateBouquetHandler : IRequestHandler<UpdateBouquetRequest, UpdateBouquetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateBouquetHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateBouquetResponse> Handle(UpdateBouquetRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetQuery()
            {
                Id = request.BouquetId
            };
            var getBouquet = await _queryExecutor.Execute(query);
            if (getBouquet is null)
            {
                return new UpdateBouquetResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBouquet = _mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
            var command = new UpdateBouquetCommand()
            {
                Parameter = mappedBouquet
            };
            var updatedBouquet = await _commandExecutor.Execute(command);
            var response = new UpdateBouquetResponse()
            {
                Data = _mapper.Map<BouquetDto>(updatedBouquet)
            };

            return response;
        }
    }
}