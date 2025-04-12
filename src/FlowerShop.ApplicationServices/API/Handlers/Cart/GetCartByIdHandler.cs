using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Cart;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.CartRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Cart;

public class GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
    : IRequestHandler<GetCartByIdRequest, GetCartByIdResponse>
{
    public async Task<GetCartByIdResponse> Handle(GetCartByIdRequest request, 
        CancellationToken cancellationToken)
    {
        if (request.CartId is null)
        {
            return new GetCartByIdResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var getCart = await cartRepository.GetCartAsync(request.CartId);
        if (getCart is null)
        {
            var newCart = new ShoppingCart
            {
                Id = request.CartId
            };

            var updatedCart = await cartRepository.UpdateCartAsync(newCart);
            if (updatedCart is null)
            {
                return new GetCartByIdResponse
                {
                    Error = new ErrorModel(ErrorType.BadRequest + " - Problem with cart")
                };
            }
            var mappedNewCart = mapper.Map<ShoppingCart, ShoppingCartDto>(updatedCart);

            return new GetCartByIdResponse
            {
                Data = mappedNewCart
            };
        }

        var shoppingCart = mapper.Map<ShoppingCart, ShoppingCartDto>(getCart);
        var response = new GetCartByIdResponse
        {
            Data = shoppingCart
        };

        return response;
    }
}