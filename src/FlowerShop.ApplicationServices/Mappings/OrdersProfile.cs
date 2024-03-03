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
                .ForMember(dest => dest.ShipToAddress, opt => opt.MapFrom(src => src.ShipToAddress))
                .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice));
            //.ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.ShipToAddress, opt => opt.MapFrom(src => src.ShipToAddress))
                .ForPath(dest => dest.DeliveryMethodId, opt => opt.MapFrom(src => src.DeliveryMethod.Id))
                .ReverseMap();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BuyerEmail, opt => opt.MapFrom(src => src.BuyerEmail))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForPath(dest => dest.ShipToAddress.FirstName, opt => opt.MapFrom(src => src.ShipToAddress.FirstName))
                .ForPath(dest => dest.ShipToAddress.LastName, opt => opt.MapFrom(src => src.ShipToAddress.LastName))
                .ForPath(dest => dest.ShipToAddress.Street, opt => opt.MapFrom(src => src.ShipToAddress.Street))
                .ForPath(dest => dest.ShipToAddress.PostalCode, opt => opt.MapFrom(src => src.ShipToAddress.PostalCode))
                .ForPath(dest => dest.ShipToAddress.City, opt => opt.MapFrom(src => src.ShipToAddress.City))
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
                .ForPath(dest => dest.ShipToAddress.FirstName, opt => opt.MapFrom(src => src.ShipToAddress.FirstName))
                .ForPath(dest => dest.ShipToAddress.LastName, opt => opt.MapFrom(src => src.ShipToAddress.LastName))
                .ForPath(dest => dest.ShipToAddress.Street, opt => opt.MapFrom(src => src.ShipToAddress.Street))
                .ForPath(dest => dest.ShipToAddress.PostalCode, opt => opt.MapFrom(src => src.ShipToAddress.PostalCode))
                .ForPath(dest => dest.ShipToAddress.City, opt => opt.MapFrom(src => src.ShipToAddress.City))
                .ForPath(dest => dest.DeliveryMethod.Id, opt => opt.MapFrom(src => src.DeliveryMethodId))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.OrderState, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Invoice, opt => opt.MapFrom(src => src.Invoice))
                .ForMember(dest => dest.PaymentIntentId, opt => opt.MapFrom(src => src.PaymentIntentId))
                .ForMember(dest => dest.Reservations, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
        }
    }
}