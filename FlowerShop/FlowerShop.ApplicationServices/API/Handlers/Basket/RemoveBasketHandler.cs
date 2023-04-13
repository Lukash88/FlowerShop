using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers.Basket
{
    public class RemoveBasketHandler : IRequestHandler<RemoveBasketRequest, RemoveBasketResponse>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public RemoveBasketHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.basketRepository = basketRepository;
        }

        public async Task<RemoveBasketResponse> Handle(RemoveBasketRequest request, CancellationToken cancellationToken)
        {
            var getBasket = await this.basketRepository.GetBasketAsync(request.BasketId);
            if (getBasket == null)
            {
                return new RemoveBasketResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var isRemoved =  await this.basketRepository.DeleteBasketAsync(request.BasketId);
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