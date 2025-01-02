using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket
{
    public class RemoveBasketHandler : IRequestHandler<RemoveBasketRequest, RemoveBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public RemoveBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        public async Task<RemoveBasketResponse> Handle(RemoveBasketRequest request, 
            CancellationToken cancellationToken)
        {
            var getBasket = await _basketRepository.GetBasketAsync(request.BasketId);
            if (getBasket is null)
            {
                return new RemoveBasketResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var isRemoved = await _basketRepository.DeleteBasketAsync(request.BasketId);
            if (!isRemoved)
            {
                return new RemoveBasketResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest)
                };
            }

            var response = new RemoveBasketResponse()
            {
                Data = null
            };

            return response;
        }
    }
}