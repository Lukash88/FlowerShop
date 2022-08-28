namespace FlowerShop.ApplicationServices.API.Domain.OrderDetail
{
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;

    public class AddOrderDetailRequest : IRequest<AddOrderDetailResponse>
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal? Price { get; set; }

        public List<Tuple<int, int>> BouquetsIdAndQuandity { get; set; } = new();
        public List<BouquetDTO> Bouquets = new();
    }
}