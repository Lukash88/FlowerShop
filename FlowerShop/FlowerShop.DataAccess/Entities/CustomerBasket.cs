namespace FlowerShop.DataAccess.Entities
{
    using System.Collections.Generic;

    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            Id = id;
        }
        
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new();
    }
}