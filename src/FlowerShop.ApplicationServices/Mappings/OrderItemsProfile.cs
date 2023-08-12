using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ItemOrdered.ProductItemId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ItemOrdered.ProductName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ItemOrdered.ImageUrl));
        }
    }
}