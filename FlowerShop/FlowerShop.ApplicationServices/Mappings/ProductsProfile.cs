namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Product;
    using FlowerShop.DataAccess.Entities;

    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<AddProductRequest, Product>()
                 .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                 .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                 .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                 .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            this.CreateMap<Product, API.Domain.Models.ProductDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            this.CreateMap<RemoveProductRequest, Product>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId));

            this.CreateMap<UpdateProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
        }
    }
}
