using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket;

public class GetBasketByIdHandler(IBasketRepository basketRepository, IMapper mapper)
    : IRequestHandler<GetBasketByIdRequest, GetBasketByIdResponse>
{
    public async Task<GetBasketByIdResponse> Handle(GetBasketByIdRequest request, 
        CancellationToken cancellationToken)
    {
        if (request.BasketId is null)
        {
            return new GetBasketByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var getBasket = await basketRepository.GetBasketAsync(request.BasketId);
        if (getBasket is null)
        {
            var newBasket = new CustomerBasket
            {
                Id = request.BasketId
            }; 
            var updatedBasket = await basketRepository.UpdateBasketAsync(newBasket);
            var mappedNewBasket = mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket);

            return new GetBasketByIdResponse
            {
                Data = mappedNewBasket
            };
        }

        var customerBasket = mapper.Map<CustomerBasket, CustomerBasketDto>(getBasket);
        var response = new GetBasketByIdResponse
        {
            Data = customerBasket
        };

        return response;
    }
}