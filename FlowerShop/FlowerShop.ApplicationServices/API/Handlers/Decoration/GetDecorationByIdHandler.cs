namespace FlowerShop.ApplicationServices.API.Handlers.Decoration
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.Decoration;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.Decoration;
    using MediatR;
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
            if (decoration == null)
            {
                return new GetDecorationByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDecoration = this.mapper.Map<Domain.Models.DecorationDTO>(decoration);
            var response = new GetDecorationByIdResponse()
            {
                Data = mappedDecoration
            };

            return response;
        }
    }
}