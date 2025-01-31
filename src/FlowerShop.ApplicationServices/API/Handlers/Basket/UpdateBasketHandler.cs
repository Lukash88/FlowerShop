using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket;

public class UpdateBasketHandler(IBasketRepository basketRepository, IMapper mapper)
    : IRequestHandler<UpdateBasketRequest, UpdateBasketResponse>
{
    public async Task<UpdateBasketResponse> Handle(UpdateBasketRequest request,
        CancellationToken cancellationToken)
    {
        request.BasketId ??= Guid.NewGuid().ToString();

        var newBasketItems = mapper.Map<UpdateBasketRequest, CustomerBasket>(request);
        var updatedBasket = await basketRepository.UpdateBasketAsync(newBasketItems);
        if (updatedBasket is null)
            return new UpdateBasketResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest)
            };

        var response = new UpdateBasketResponse
        {
            Data = mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket)
        };

        return response;
    }
}