using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class
        GetDeliveryMethodByIdHandler : IRequestHandler<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetDeliveryMethodByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetDeliveryMethodByIdResponse> Handle(GetDeliveryMethodByIdRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveryMethodQuery()
            {
                Id = request.MethodId
            };
            var deliveryMethod = await _queryExecutor.Execute(query);
            if (deliveryMethod is null)
            {
                return new GetDeliveryMethodByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDeliveryMethod = _mapper.Map<DeliveryMethodDto>(deliveryMethod);
            var response = new GetDeliveryMethodByIdResponse()
            {
                Data = mappedDeliveryMethod
            };

            return response;
        }
    }
}