using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Components.Sieve.Configurations
{
    public class SieveConfigurationForOrderDetail : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<OrderDetail>(od => od.Name)
               .CanSort()
               .CanFilter(); ;

            mapper.Property<OrderDetail>(od => od.Category)
                .CanSort()
                .CanFilter();

            mapper.Property<OrderDetail>(od => od.Price)
                .CanSort()
                .CanFilter();
        }
    }
}
