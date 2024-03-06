using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.DataAccess.Repositories.BasketRepository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FlowerShop.Controllers
{
    [Authorize]
    public class BasketController : ApiControllerBase
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper,
            IMediator mediator, ILogger<BasketController> logger) : base(mediator, logger)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
            logger.LogInformation("We are in Basket Controller");
        }

        [HttpGet]
        [Route("{basketId}")]
        public async Task<IActionResult> GetBasketById([FromRoute] string basketId)
        {
            var request = new GetBasketByIdRequest()
            {
                BasketId = basketId
            };

            return await this.HandleRequest<GetBasketByIdRequest, GetBasketByIdResponse>(request);
        }
        
        [HttpPost]
        [Route("{basketId}")]
        public async Task<IActionResult> UpdateBasket([FromRoute] string basketId, [FromBody] UpdateBasketRequest request)
        {
            request.BasketId = basketId;

            return await this.HandleRequest<UpdateBasketRequest, UpdateBasketResponse>(request);
        }

        [HttpDelete]
        [Route("{basketId}")]
        public async Task<IActionResult> DeleteBasketAsync([FromRoute] string basketId)
        {
            var request = new RemoveBasketRequest()
            {
                BasketId = basketId
            };

            return await this.HandleRequest<RemoveBasketRequest, RemoveBasketResponse>(request);
        }  
    }
}