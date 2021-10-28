namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Decoration;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetDecorationsHandler : IRequestHandler<GetDecorationsRequest, GetDecorationsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDecorationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDecorationsResponse> Handle(GetDecorationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationsQuery()
            {
                Name = request.Name
            };
            var decorations = await this.queryExecutor.Execute(query);
            var mappedDecorations = this.mapper.Map<List<Domain.Models.Decoration>>(decorations);
            var response = new GetDecorationsResponse()
            {
                Data = mappedDecorations
            };

            return response;
        }
    }
}
