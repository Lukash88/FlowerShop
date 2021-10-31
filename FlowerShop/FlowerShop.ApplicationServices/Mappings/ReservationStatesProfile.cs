namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.Models;

    public class ReservationStatesProfile : Profile
    {
        public ReservationStatesProfile()
        {
            this.CreateMap<DataAccess.Entities.ReservationState, ReservationStateDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus));
        }
    }
}
