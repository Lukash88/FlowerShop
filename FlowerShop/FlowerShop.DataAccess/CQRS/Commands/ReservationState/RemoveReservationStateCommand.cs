namespace FlowerShop.DataAccess.CQRS.Commands.ReservationState
{
    using FlowerShop.DataAccess.Entities;
    using System.Threading.Tasks;

    public class RemoveReservationStateCommand : CommandBase<ReservationState, ReservationState>
    {
        public override async Task<ReservationState> Execute(FlowerShopStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.ReservationStates.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
