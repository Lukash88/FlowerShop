using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Decoration;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Decoration;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Decoration;

public class GetDecorationByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetDecorationByIdRequest, GetDecorationByIdResponse>
{
    public async Task<GetDecorationByIdResponse> Handle(GetDecorationByIdRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetDecorationQuery
        {
            Id = request.DecorationId
        };
        var decoration = await queryExecutor.Execute(query);
        if (decoration is null)
        {
            return new GetDecorationByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedDecoration = mapper.Map<DecorationDto>(decoration);
        var response = new GetDecorationByIdResponse
        {
            Data = mappedDecoration
        };

        return response;
    }
}