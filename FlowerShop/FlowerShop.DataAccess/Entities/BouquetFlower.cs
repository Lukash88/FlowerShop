using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DataAccess.Entities
{
    public class BouquetFlower
    {
        public int BouquetId { get; set; }
        public Bouquet Bouquet { get; set; }

        public int FlowerId { get; set; }
        public Flower Flower { get; set; }
        public int FlowerQuantity { get; set; }
    }
}
