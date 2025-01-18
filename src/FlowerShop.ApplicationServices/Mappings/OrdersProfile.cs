using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<AddOrderRequest, Order>()
                .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
                .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
                .ForPath(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethod.Id))
                .ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForPath(dest => dest.ShippingAddress.FirstName, opt => opt.MapFrom(src => src.ShippingAddress.FirstName))
                .ForPath(dest => dest.ShippingAddress.LastName, opt => opt.MapFrom(src => src.ShippingAddress.LastName))
                .ForPath(dest => dest.ShippingAddress.Street, opt => opt.MapFrom(src => src.ShippingAddress.Street))
                .ForPath(dest => dest.ShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShippingAddress.PostalCode))
                .ForPath(dest => dest.ShippingAddress.City, opt => opt.MapFrom(src => src.ShippingAddress.City))
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.ShippingPrice, opt => opt.MapFrom(src => src.DeliveryMethod.Price))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.GetTotal()))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OrderState));

            CreateMap<RemoveOrderRequest, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));

            CreateMap<UpdateOrderRequest, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForPath(dest => dest.ShippingAddress.FirstName, opt => opt.MapFrom(src => src.ShipToShippingAddress.FirstName))
                .ForPath(dest => dest.ShippingAddress.LastName, opt => opt.MapFrom(src => src.ShipToShippingAddress.LastName))
                .ForPath(dest => dest.ShippingAddress.Street, opt => opt.MapFrom(src => src.ShipToShippingAddress.Street))
                .ForPath(dest => dest.ShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShipToShippingAddress.PostalCode))
                .ForPath(dest => dest.ShippingAddress.City, opt => opt.MapFrom(src => src.ShipToShippingAddress.City))
                .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();

            CreateMap<AddOrderRequest, UpdateOrderRequest>()
                .ForMember(dest => dest.BasketId, opt => opt.MapFrom(src => src.BasketId))
                .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
                .ForPath(dest => dest.ShipToShippingAddress.FirstName, opt => opt.MapFrom(src => src.ShippingAddress.FirstName))
                .ForPath(dest => dest.ShipToShippingAddress.LastName, opt => opt.MapFrom(src => src.ShippingAddress.LastName))
                .ForPath(dest => dest.ShipToShippingAddress.Street, opt => opt.MapFrom(src => src.ShippingAddress.Street))
                .ForPath(dest => dest.ShipToShippingAddress.PostalCode, opt => opt.MapFrom(src => src.ShippingAddress.PostalCode))
                .ForPath(dest => dest.ShipToShippingAddress.City, opt => opt.MapFrom(src => src.ShippingAddress.City))
                .ForPath(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}