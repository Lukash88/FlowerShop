namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class UpdateFlowerRequest : IRequest<UpdateFlowerResponse>
    {
        public object Id { get; set; }
        public int FlowerId { get; init; }
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public byte LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
    }
}
