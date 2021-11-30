namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBouquetsHandler : IRequestHandler<GetBouquetsRequest, GetBouquetsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBouquetsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }        

        public async Task<GetBouquetsResponse> Handle(GetBouquetsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetsQuery()
            {
                Occasion = request.Occasion
            };
            var bouquets = await this.queryExecutor.Execute(query);
            if (bouquets == null)
            {
                return new GetBouquetsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBouquets = this.mapper.Map<List<Domain.Models.BouquetDTO>>(bouquets);
            var response = new GetBouquetsResponse()
            {
                Data = mappedBouquets
            };

            return response;
        }
    }
}