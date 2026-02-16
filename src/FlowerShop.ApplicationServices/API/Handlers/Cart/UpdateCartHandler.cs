using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Cart;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Repositories.CartRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Cart;

public class UpdateCartHandler(ICartRepository cartRepository, IMapper mapper)
    : IRequestHandler<UpdateCartRequest, UpdateCartResponse>
{
    public async Task<UpdateCartResponse> Handle(UpdateCartRequest request,
        CancellationToken cancellationToken)
    {
        request.Id ??= Guid.NewGuid().ToString();

        var newCartItems = mapper.Map<UpdateCartRequest, ShoppingCart>(request);
        var updatedCart = await cartRepository.UpdateCartAsync(newCartItems);
        if (updatedCart is null)
            return new UpdateCartResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest)
            };

        var response = new UpdateCartResponse
        {
            Data = mapper.Map<ShoppingCart, ShoppingCartDto>(updatedCart)
        };

        return response;
    }
}