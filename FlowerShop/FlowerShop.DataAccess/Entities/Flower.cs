using System.Collections.Generic;

namespace FlowerShop.DataAccess.Entities
{
    public class Flower : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }


       public List<Bouquet> Bouquets { get; set; } = new List<Bouquet>();
    }
}