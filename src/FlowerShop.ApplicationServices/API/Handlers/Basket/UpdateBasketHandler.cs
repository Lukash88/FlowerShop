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
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public UpdateBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateBasketResponse> Handle(UpdateBasketRequest request, 
            CancellationToken cancellationToken)
        {
            var newBasketItems = this.mapper.Map<UpdateBasketRequest, CustomerBasket>(request);
            var updatedBasket = await this.basketRepository.UpdateBasketAsync(newBasketItems);
            if (updatedBasket is null)
            {
                return new UpdateBasketResponse()
                {
                    Error = new ErrorModel(ErrorType.BadRequest)
                };
            }

            var response = new UpdateBasketResponse()
            {
                Data = this.mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket)
            };

            return response;
        }
    }
}