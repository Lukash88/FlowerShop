using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Mappings;

public class OrdersProfile : Profile
{
    public OrdersProfile()
    {
        CreateMap<AddOrderRequest, Order>()
            .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
            .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.PaymentSummary, opt => opt.MapFrom(src => src.PaymentSummary))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
            .ForPath(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethod.Id))
            .ForMember(dest => dest.PaymentSummary, opt => opt.MapFrom(src => src.PaymentSummary))
            .ReverseMap();

        CreateMap<Order, OrderToReturnDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
            .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
            .ForMember(dest => dest.PaymentSummary, opt => opt.MapFrom(src => src.PaymentSummary))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
            .ForMember(dest => dest.ShippingPrice, opt => opt.MapFrom(src => src.DeliveryMethod.Price))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.GetTotal()))
            .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderState));

        CreateMap<RemoveOrderRequest, Order>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdateOrderRequest, Order>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForPath(dest => dest.ShippingAddress.Name, opt => opt.MapFrom(src => src.ShippingAddress.Name))
            .ForPath(dest => dest.ShippingAddress.Line1, opt => opt.MapFrom(src => src.ShippingAddress.Line1))
            .ForPath(dest => dest.ShippingAddress.Line2, opt => opt.MapFrom(src => src.ShippingAddress.Line2))
            .ForPath(dest => dest.ShippingAddress.City, opt => opt.MapFrom(src => src.ShippingAddress.City))
            .ForPath(dest => dest.ShippingAddress.State, opt => opt.MapFrom(src => src.ShippingAddress.State))
            .ForPath(dest => dest.ShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShippingAddress.PostalCode))
            .ForPath(dest => dest.ShippingAddress.Country, opt => opt.MapFrom(src => src.ShippingAddress.Country))
            .ForPath(dest => dest.ShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShippingAddress.PostalCode))
            .ForPath(dest => dest.ShippingAddress.City, opt => opt.MapFrom(src => src.ShippingAddress.City))
            .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.PaymentSummary, opt => opt.MapFrom(src => src.PaymentSummary))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ReverseMap();

        CreateMap<AddOrderRequest, UpdateOrderRequest>()
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId))
            .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
            .ForPath(dest => dest.ShippingAddress.Name, opt => opt.MapFrom(src => src.ShippingAddress.Name))
            .ForPath(dest => dest.ShippingAddress.Line1, opt => opt.MapFrom(src => src.ShippingAddress.Line1))
            .ForPath(dest => dest.ShippingAddress.Line2, opt => opt.MapFrom(src => src.ShippingAddress.Line2))
            .ForPath(dest => dest.ShippingAddress.City, opt => opt.MapFrom(src => src.ShippingAddress.City))
            .ForPath(dest => dest.ShippingAddress.State, opt => opt.MapFrom(src => src.ShippingAddress.State))
            .ForPath(dest => dest.ShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShippingAddress.PostalCode))
            .ForPath(dest => dest.ShippingAddress.Country, opt => opt.MapFrom(src => src.ShippingAddress.Country))
            .ForPath(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
            .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
            .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}