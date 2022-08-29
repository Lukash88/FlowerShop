namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            this.CreateMap<AddOrderDetailRequest, OrderDetail>()
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))   
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Bouquets, y => y.MapFrom(z => z.Bouquets ?? new List<BouquetDTO>()))
                .ForMember(x => x.Decorations, y => y.MapFrom(z => z.Decorations ?? new List<DecorationDTO>()));

            this.CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Bouquets, y => y.MapFrom(z => z.Bouquets ?? new List<Bouquet>()))
                .ForMember(x => x.Decorations, y => y.MapFrom(z => z.Decorations ?? new List<Decoration>()));

            this.CreateMap<RemoveOrderDetailRequest, OrderDetail>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderDetailId));

            this.CreateMap<UpdateOrderDetailRequest, OrderDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderDetailId))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }                                                                                             
    }
}