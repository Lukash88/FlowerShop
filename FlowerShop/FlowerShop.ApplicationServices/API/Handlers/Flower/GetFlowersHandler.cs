using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
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
            var mappedFlowers = this.mapper.Map<List<Domain.Models.Flower>>(flowers);
            var response = new GetFlowersResponse()
            {
                Data = mappedFlowers
            };

            return response;
        }
    }
}
