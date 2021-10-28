namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Decoration;
    using MediatR;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetDecorationByIdHandler : IRequestHandler<GetDecorationByIdRequest, GetDecorationByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDecorationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDecorationByIdResponse> Handle(GetDecorationByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDecorationQuery()
            {
                Id = request.DecorationId
            };
            var decoration = await this.queryExecutor.Execute(query);
            var mappedDecoration = this.mapper.Map<Domain.Models.Decoration>(decoration);
            var response = new GetDecorationByIdResponse()
            {
                Data = mappedDecoration
            };

            return response;
        }
    }
}
