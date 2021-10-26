namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            this.CreateMap<DataAccess.Entities.OrderDetail, OrderDetail>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProductQuantity, y => y.MapFrom(z => z.ProductQuantity))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(z => z.CreatedAt))
                .ForMember(x => x.OrderState, y => y.MapFrom(z => z.OrderState));
        }
    }
}
