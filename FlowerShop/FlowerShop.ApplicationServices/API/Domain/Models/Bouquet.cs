using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class Bouquet
    {
        public int Id { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }
    }
}
