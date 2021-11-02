namespace FlowerShop.DataAccess.CQRS.Queries.ReservationState
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class GetReservationStateQuery : QueryBase<ReservationState>
    {
        public int Id { get; init; }

        public override async Task<ReservationState> Execute(FlowerShopStorageContext context) =>
            await context.ReservationStates.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
