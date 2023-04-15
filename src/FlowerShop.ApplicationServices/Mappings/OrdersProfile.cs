using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Order;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            this.CreateMap<AddOrderRequest, Order>()
                //.ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.Sum, y => y.MapFrom(z => z.Sum));

            this.CreateMap<Order, OrderDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                //.ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.Sum, y => y.MapFrom(z => z.Sum))
                .ForMember(x => x.Reservations, y => y.MapFrom(z => z.Reservations))
                .ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails))
                .ReverseMap();

            this.CreateMap<Reservation, ReservationDto>().ReverseMap();
            
            this.CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            this.CreateMap<RemoveOrderRequest, Order>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderId));

            this.CreateMap<UpdateOrderRequest, Order>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderId))
                //.ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.IsPaymentConfirmed, y => y.MapFrom(z => z.IsPaymentConfirmed))
                .ForMember(x => x.Invoice, y => y.MapFrom(z => z.Invoice))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.Sum, y => y.MapFrom(z => z.Sum));
        }
    }
}