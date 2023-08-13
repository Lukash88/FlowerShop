using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain.DeliveryMethod;
using FlowerShop.ApplicationServices.API.Domain.Models;
using FlowerShop.DataAccess.Core.Entities.OrderAggregate;

namespace FlowerShop.ApplicationServices.Mappings
{
    public class DeliveryMethodsProfile : Profile
    {
        public DeliveryMethodsProfile()
        {
            CreateMap<AddDeliveryMethodRequest, DeliveryMethod>()
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.DeliveryTime, opt => opt.MapFrom(src => src.DeliveryTime))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<DeliveryMethod, DeliveryMethodDto>().ReverseMap();

            CreateMap<RemoveDeliveryMethodRequest, DeliveryMethod>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MethodId));

            CreateMap<UpdateDeliveryMethodRequest, DeliveryMethod>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MethodId))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.DeliveryTime, opt => opt.MapFrom(src => src.DeliveryTime))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}