using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.Entities
{
    public class Bouquet : EntityBase
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public List<Flower> Flowers { get; set; } = new List<Flower>();

    }
}
