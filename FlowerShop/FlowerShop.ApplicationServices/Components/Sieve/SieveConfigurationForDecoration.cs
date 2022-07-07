﻿using FlowerShop.DataAccess.Entities;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.Components.Sieve
{
    public class SieveConfigurationForDecoration : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Decoration>(d => d.Name)
               .CanSort()
               .CanFilter();

            mapper.Property<Decoration>(d => d.Role)
                .CanSort()
                .CanFilter();

            mapper.Property<Decoration>(d => d.Price)
                .CanSort()
                .CanFilter();
        }
    }
}
