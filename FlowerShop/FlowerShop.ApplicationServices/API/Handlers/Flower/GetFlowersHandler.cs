namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFlowersHandler : IRequestHandler<GetFlowersRequest, GetFlowersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetFlowersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetFlowersResponse> Handle(GetFlowersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetFlowersQuery() 
            { 
                Name = request.Name
            };
            var flowers = await this.queryExecutor.Execute(query);
            if (flowers == null)
            {
                return new GetFlowersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedFlowers = this.mapper.Map<List<Domain.Models.FlowerDTO>>(flowers);
            var response = new GetFlowersResponse()
            {
                Data = mappedFlowers
            };

            return response;
        }
    }
}
