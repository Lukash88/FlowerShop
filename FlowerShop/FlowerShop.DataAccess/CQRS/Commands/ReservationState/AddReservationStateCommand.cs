namespace FlowerShop.DataAccess.CQRS.Commands.ReservationState
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class AddReservationStateCommand : CommandBase<ReservationState, ReservationState>
    {
        public override async Task<ReservationState> Execute(FlowerShopStorageContext context)
        {
            await context.ReservationStates.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
