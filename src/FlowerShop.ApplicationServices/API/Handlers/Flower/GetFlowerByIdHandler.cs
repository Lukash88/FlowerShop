using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Flower;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.Flower;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Flower;

public class GetFlowerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetFlowerByIdRequest, GetFlowerByIdResponse>
{
    public async Task<GetFlowerByIdResponse> Handle(GetFlowerByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetFlowerQuery
        {
            Id = request.FlowerId
        };
        var flower = await queryExecutor.Execute(query);
        if (flower is null)
        {
            return new GetFlowerByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedFlower = mapper.Map<Domain.Models.FlowerDto>(flower);
        var response = new GetFlowerByIdResponse
        {
            Data = mappedFlower
        };

        return response;
    }
}