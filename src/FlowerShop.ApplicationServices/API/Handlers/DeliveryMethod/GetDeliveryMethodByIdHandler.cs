using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.DeliveryMethod;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.DeliveryMethod
{
    public class
        GetDeliveryMethodByIdHandler : IRequestHandler<GetDeliveryMethodByIdRequest, GetDeliveryMethodByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetDeliveryMethodByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetDeliveryMethodByIdResponse> Handle(GetDeliveryMethodByIdRequest request,
            CancellationToken cancellationToken)
        {
            var query = new GetDeliveryMethodQuery()
            {
                Id = request.MethodId
            };
            var deliveryMethod = await this.queryExecutor.Execute(query);
            if (deliveryMethod is null)
            {
                return new GetDeliveryMethodByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedDeliveryMethod = this.mapper.Map<DeliveryMethodDto>(deliveryMethod);
            var response = new GetDeliveryMethodByIdResponse()
            {
                Data = mappedDeliveryMethod
            };

            return response;
        }
    }
}