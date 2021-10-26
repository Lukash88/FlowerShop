namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class OrderItemsProfile : Profile
    {
        public OrderItemsProfile()
        {
            this.CreateMap<DataAccess.Entities.OrderItem, OrderItem>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
        }
    }
}
