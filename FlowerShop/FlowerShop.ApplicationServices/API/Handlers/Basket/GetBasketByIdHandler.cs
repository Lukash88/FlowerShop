using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket
{
    public class GetBasketByIdHandler : IRequestHandler<GetBasketByIdRequest, GetBasketByIdResponse>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetBasketByIdHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<GetBasketByIdResponse> Handle(GetBasketByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.BasketId == null)
            {
                return new GetBasketByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var getBasket = await this.basketRepository.GetBasketAsync(request.BasketId);
            if (getBasket == null)
            {
                var newBasket = new CustomerBasket(request.BasketId);
                var mappedNewBasket = this.mapper.Map<CustomerBasket, CustomerBasketDto>(newBasket);

                return new GetBasketByIdResponse()
                {
                    Data = mappedNewBasket
                };
            }

            var customerBasket = this.mapper.Map<CustomerBasket, CustomerBasketDto>(getBasket);
            var response = new GetBasketByIdResponse()
            {
                Data = customerBasket
            };

            return response;
        }
    }
}