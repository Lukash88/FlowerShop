namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Bouquet;
    using FlowerShop.ApplicationServices.API.Domain.Models;
    using FlowerShop.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public class BouquetsProfile : Profile
    {
        public BouquetsProfile()
        {
            this.CreateMap<AddBouquetRequest, Bouquet>()
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers ?? new List<FlowerDTO>()));

            this.CreateMap<Bouquet, BouquetFlower>()
                .ForMember(x => x.BouquetId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FlowerId, y => y.MapFrom(z => z.Flowers.Select(x => x.Id)));

            this.CreateMap<Bouquet, API.Domain.Models.BouquetDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel))
                .ForMember(x => x.Flowers, y => y.MapFrom(z => z.Flowers ?? new List<Flower>()));

            this.CreateMap<RemoveBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId));

            this.CreateMap<UpdateBouquetRequest, Bouquet>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.BouquetId))
                .ForMember(x => x.Occasion, y => y.MapFrom(z => z.Occasion))
                .ForMember(x => x.TypeOfArrangement, y => y.MapFrom(z => z.TypeOfArrangement))
                .ForMember(x => x.DecorationWay, y => y.MapFrom(z => z.DecorationWay))
                .ForMember(x => x.StockLevel, y => y.MapFrom(z => z.StockLevel));
        }
    }
}