using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.Core.Entities;

namespace FlowerShop.ApplicationServices.Mappings;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<AddProductRequest, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.LongDescription, opt => opt.MapFrom(src => src.LongDescription))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.ImageThumbnailUrl, opt => opt.MapFrom(src => src.ImageThumbnailUrl))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.LongDescription, opt => opt.MapFrom(src => src.LongDescription))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.ImageThumbnailUrl, opt => opt.MapFrom(src => src.ImageThumbnailUrl))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel))
            .ReverseMap();

        CreateMap<RemoveProductRequest, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

        CreateMap<UpdateProductRequest, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ShortDescription))
            .ForMember(dest => dest.LongDescription, opt => opt.MapFrom(src => src.LongDescription))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.ImageThumbnailUrl, opt => opt.MapFrom(src => src.ImageThumbnailUrl))
            .ForMember(dest => dest.StockLevel, opt => opt.MapFrom(src => src.StockLevel));
    }
}