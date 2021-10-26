namespace FlowerShop.ApplicationServices.API.Handlers.Flower
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Flower;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFlowerByIdHandler : IRequestHandler<GetFlowerByIdRequest, GetFlowerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetFlowerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetFlowerByIdResponse> Handle(GetFlowerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetFlowerQuery()
            {
                Id = request.FlowerId
            };

            var flower = await this.queryExecutor.Execute(query);
            var mappedFlower = this.mapper.Map<Domain.Models.Flower>(flower);
            var response = new GetFlowerByIdResponse()
            {
                Data = mappedFlower
            };

            return response;
        }
    }
}
