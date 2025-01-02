using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet
{
    public class GetBouquetByIdHandler : IRequestHandler<GetBouquetByIdRequest, GetBouquetByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetBouquetByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetBouquetByIdResponse> Handle(GetBouquetByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBouquetQuery()
            {
                Id = request.BouquetId
            };
            var bouquet = await _queryExecutor.Execute(query);  
            if (bouquet is null)
            {
                return new GetBouquetByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBouquet = _mapper.Map<BouquetDto>(bouquet);
            var response = new GetBouquetByIdResponse()
            {
                Data = mappedBouquet
            };

            return response;
        }
    }
}