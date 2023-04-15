using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Basket;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            this.CreateMap<CustomerBasketDto, CustomerBasket>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ReverseMap();

            this.CreateMap<BasketItemDto, BasketItem>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ReverseMap();

            this.CreateMap<UpdateBasketRequest, CustomerBasket>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BasketId))
                .ForMember(x => x.Items, y => y.MapFrom(z => z.Items));
        }
    }
}