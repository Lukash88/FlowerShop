﻿using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class AddBouquetHandler : IRequestHandler<AddBouquetRequest, AddBouquetResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddBouquetHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddBouquetResponse> Handle(AddBouquetRequest request, CancellationToken cancellationToken)
        {
            var bouquet = this.mapper.Map<DataAccess.Core.Entities.Bouquet>(request);
            var command = new AddBouquetCommand()
            {
                Parameter = bouquet
            };
            var addedBouquet = await this.commandExecutor.Execute(command);
            var response = new AddBouquetResponse()
            {
                Data = this.mapper.Map<BouquetDto>(addedBouquet)
            };

            return response;
        }
    }
}