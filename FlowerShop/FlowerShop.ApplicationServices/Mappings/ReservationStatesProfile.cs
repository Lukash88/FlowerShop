namespace FlowerShop.ApplicationServices.Mappings
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.ReservationState;
    using FlowerShop.DataAccess.Entities;

    public class ReservationStatesProfile : Profile
    {
        public ReservationStatesProfile()
        {
            this.CreateMap<AddReservationStateRequest, ReservationState>()
                .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus));

            this.CreateMap<ReservationState, API.Domain.Models.ReservationStateDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus));

            this.CreateMap<RemoveReservationStateRequest, ReservationState>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationStateId));

            this.CreateMap<UpdateReservationStateRequest, ReservationState>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.ReservationStateId))
                .ForMember(x => x.ReservationId, y => y.MapFrom(z => z.ReservationId))
                .ForMember(x => x.ReservationStatus, y => y.MapFrom(z => z.ReservationStatus));
        }
    }
}
