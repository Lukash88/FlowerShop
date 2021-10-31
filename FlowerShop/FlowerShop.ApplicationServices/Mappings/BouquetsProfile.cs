namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.DataAccess.Entities;

    public class BouquetsProfile : Profile
    {
        public BouquetsProfile()
        {
            this.CreateMap<AddBouquetRequest, Bouquet>()
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay));

            this.CreateMap<Bouquet, API.Domain.Models.BouquetDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay));

            this.CreateMap<RemoveBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId));

            this.CreateMap<UpdateBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay));
        }
    }
}
