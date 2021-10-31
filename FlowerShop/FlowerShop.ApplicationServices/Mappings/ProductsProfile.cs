namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<DataAccess.Entities.Product, ProductDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription));
        }
    }
}
