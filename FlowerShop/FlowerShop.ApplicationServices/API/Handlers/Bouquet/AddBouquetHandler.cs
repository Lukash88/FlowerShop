namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.Bouquet;
    using FlowerShop.DataAccess.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

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
            var bouquet = this.mapper.Map<Bouquet>(request);
            var command = new AddBouquetCommand() 
            { 
                Parameter = bouquet 
            };
            if (command == null)
            {
                return new AddBouquetResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };                
            }

            var bouquetFromDb = await this.commandExecutor.Execute(command);
            var response = new AddBouquetResponse()
            {
                Data = this.mapper.Map<Domain.Models.BouquetDTO>(bouquetFromDb)
            };

            return response;
        }
    }
}