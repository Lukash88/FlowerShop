using System.Threading.Tasks;
using FlowerShop.DataAccess;
using FlowerShop.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await this.basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket) 
        {
            var updatedBasket = await this.basketRepository.UpdateBasketAsync(basket);

            return Ok(basket);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id) =>        
            await this.basketRepository.DeleteBasketAsync(id);   
    }
}