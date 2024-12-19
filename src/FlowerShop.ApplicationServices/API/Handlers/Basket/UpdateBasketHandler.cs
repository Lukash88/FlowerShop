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
    public class UpdateBasketHandler : IRequestHandler<UpdateBasketRequest, UpdateBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UpdateBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBasketResponse> Handle(UpdateBasketRequest request,
            CancellationToken cancellationToken)
        {
            if (request.BasketId is null)
            {
                var newBasket = new CustomerBasket();
                request.BasketId = newBasket.Id;
            }

            var newBasketItems = _mapper.Map<UpdateBasketRequest, CustomerBasket>(request);
            var updatedBasket = await _basketRepository.UpdateBasketAsync(newBasketItems);
            if (updatedBasket is null)
                return new UpdateBasketResponse
                {
                    Error = new ErrorModel(ErrorType.BadRequest)
                };

            var response = new UpdateBasketResponse
            {
                Data = _mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket)
            };

            return response;
        }
    }
}