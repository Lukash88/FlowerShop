using System;
using System.Collections.Generic;
using FlowerShop.ApplicationServices.API.Domain.Models;
using MediatR;

namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    public class AddOrderDetailRequest : IRequest<AddOrderDetailResponse>
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public List<Tuple<int, int>> BouquetsIdAndQuantity { get; set; } = new();
        public List<BouquetDto> Bouquets = new();

        public List<Tuple<int, int>> DecorationsIdAndQuantity { get; set; } = new();
        public List<DecorationDto> Decorations = new();

        public List<Tuple<int, int>> ProductsIdAndQuantity { get; set; } = new();
        public List<ProductDto> Products = new();
    }
}