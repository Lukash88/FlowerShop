namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.OrderItem;
    using FlowerShop.DataAccess.Entities;

    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            this.CreateMap<AddOrderItemRequest, OrderItem>()
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
               .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            this.CreateMap<OrderItem, API.Domain.Models.OrderItemDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.OrderDetailId, y => y.MapFrom(z => z.OrderDetailId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            this.CreateMap<RemoveOrderItemRequest, OrderItem>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderItemId));

            this.CreateMap<UpdateOrderItemRequest, OrderItem>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.OrderItemId))
               .ForMember(x => x.OrderDetailId, y => y.MapFrom(z => z.OrderDetailId))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
               .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
        }
    }
}
