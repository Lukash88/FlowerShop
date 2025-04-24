using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Cart;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Repositories.CartRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Cart;

public class RemoveCartHandler(ICartRepository cartRepository)
    : IRequestHandler<RemoveCartRequest, RemoveCartResponse>
{
    public async Task<RemoveCartResponse> Handle(RemoveCartRequest request, 
        CancellationToken cancellationToken)
    {
        var getCart = await cartRepository.GetCartAsync(request.CartId);
        if (getCart is null)
        {
            return new RemoveCartResponse
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var isRemoved = await cartRepository.DeleteCartAsync(request.CartId);
        if (!isRemoved)
        {
            return new RemoveCartResponse
            {
                Error = new ErrorModel(ErrorType.BadRequest)
            };
        }

        var response = new RemoveCartResponse
        {
            Data = null
        };

        return response;
    }
}