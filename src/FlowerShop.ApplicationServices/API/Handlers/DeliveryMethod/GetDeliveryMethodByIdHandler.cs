using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod;

public class
    GetDeliveryMethodByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    : IRequestHandler<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>
{
    public async Task<GetDeliveryMethodByIdResponse> Handle(GetDeliveryMethodByIdRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetDeliveryMethodQuery
        {
            Id = request.MethodId
        };
        var deliveryMethod = await queryExecutor.Execute(query);
        if (deliveryMethod is null)
        {
            return new GetDeliveryMethodByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedDeliveryMethod = mapper.Map<DeliveryMethodDto>(deliveryMethod);
        var response = new GetDeliveryMethodByIdResponse
        {
            Data = mappedDeliveryMethod
        };

        return response;
    }
}