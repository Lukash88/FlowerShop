﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain.Product
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public string Name { get; init; }
    }
}
