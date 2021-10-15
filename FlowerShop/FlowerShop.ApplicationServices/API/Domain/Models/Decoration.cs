using FlowerShop.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    public class Decoration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Roles { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
