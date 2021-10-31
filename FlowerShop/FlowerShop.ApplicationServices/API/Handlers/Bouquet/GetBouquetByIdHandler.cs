namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBouquetByIdHandler : IRequestHandler<GetBouquetByIdRequest, GetBouquetByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBouquetByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetBouquetByIdResponse> Handle(GetBouquetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetQuery()
            {
                Id = request.BouquetId
            };
            var bouquet = await this.queryExecutor.Execute(query);  
            var mappedBouquet = this.mapper.Map<Domain.Models.BouquetDTO>(bouquet);
            var response = new GetBouquetByIdResponse()
            {
                Data = mappedBouquet
            };

            return response;
        }
    }
}