namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Flower;
    using FlowerShop.DataAccess.Entities;

    public class FlowersProfile : Profile
    {
        public FlowersProfile()
        {
            this.CreateMap<AddFlowerRequest, Flower>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));


            this.CreateMap<Flower, API.Domain.Models.FlowerDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Bouquets, y => y.MapFrom(z => z.Bouquets));

            this.CreateMap<RemoveFlowerRequest, Flower>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.FlowerId));

            this.CreateMap<UpdateFlowerRequest, Flower>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.FlowerId))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.FlowerType, y => y.MapFrom(z => z.FlowerType))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.LengthInCm, y => y.MapFrom(z => z.LengthInCm))
                .ForMember(x => x.Colour, y => y.MapFrom(z => z.Colour))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }
    }
}