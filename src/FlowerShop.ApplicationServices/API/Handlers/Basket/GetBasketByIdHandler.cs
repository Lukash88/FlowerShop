using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket
{
    public class GetBasketByIdHandler : IRequestHandler<GetBasketByIdRequest, GetBasketByIdResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public GetBasketByIdHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<GetBasketByIdResponse> Handle(GetBasketByIdRequest request, 
            CancellationToken cancellationToken)
        {
            if (request.BasketId is null)
            {
                return new GetBasketByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var getBasket = await _basketRepository.GetBasketAsync(request.BasketId);
            if (getBasket is null)
            {
                var newBasket = new CustomerBasket(request.BasketId); 
                var updatedBasket = await _basketRepository.UpdateBasketAsync(newBasket);
                var mappedNewBasket = _mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket);

                return new GetBasketByIdResponse()
                {
                    Data = mappedNewBasket
                };
            }

            var customerBasket = _mapper.Map<CustomerBasket, CustomerBasketDto>(getBasket);
            var response = new GetBasketByIdResponse()
            {
                Data = customerBasket
            };

            return response;
        }
    }
}