using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Bouquet;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Bouquet;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Bouquet;

public class GetBouquetByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetBouquetByIdRequest, GetBouquetByIdResponse>
{
    public async Task<GetBouquetByIdResponse> Handle(GetBouquetByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetBouquetQuery
        {
            Id = request.BouquetId
        };
        var bouquet = await queryExecutor.Execute(query);  
        if (bouquet is null)
        {
            return new GetBouquetByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedBouquet = mapper.Map<BouquetDto>(bouquet);
        var response = new GetBouquetByIdResponse
        {
            Data = mappedBouquet
        };

        return response;
    }
}