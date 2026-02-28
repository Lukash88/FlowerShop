using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Cart;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities;
using FlowerShop.DataAccess.Core.Enums;

namespace FlowerShop.ApplicationServices.Mappings;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon));

        CreateMap<ShoppingCartDto, ShoppingCart>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon));

        
        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

        CreateMap<CartItemDto, CartItem>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse<Category>(src.Category, true)))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        
        CreateMap<UpdateCartRequest, ShoppingCart>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Coupon, opt => opt.MapFrom(src => src.Coupon));
    }
}