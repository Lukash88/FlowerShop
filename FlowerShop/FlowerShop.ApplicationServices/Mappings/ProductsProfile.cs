using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<AddProductRequest, Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));

            this.CreateMap<Product, ProductDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                //.ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.OrderDetails))
                .ReverseMap();

            this.CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            this.CreateMap<RemoveProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId));

            this.CreateMap<UpdateProductRequest, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription))
                .ForMember(x => x.LongDescription, y => y.MapFrom(z => z.LongDescription))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));
        }
    }
}