namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderDetail;
    using FlowerShop.DataAccess.Entities;

    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            this.CreateMap<AddOrderDetailRequest, OrderDetail>()
               .ForMember(x => x.ProductQuantity, y => y.MapFrom(z => z.ProductQuantity))
               .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
               .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
               .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState));

            this.CreateMap<OrderDetail, API.Domain.Models.OrderDetailDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.ProductQuantity, y => y.MapFrom(z => z.ProductQuantity))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState));

            this.CreateMap<RemoveOrderDetailRequest, OrderDetail>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderDetailId));

            this.CreateMap<UpdateOrderDetailRequest, OrderDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderDetailId))
                .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.ProductQuantity, y => y.MapFrom(z => z.ProductQuantity))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState));
        }
    }
}