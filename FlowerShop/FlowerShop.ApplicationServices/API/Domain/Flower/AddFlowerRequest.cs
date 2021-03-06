namespace FlowerShop.ApplicationServices.API.Domain.Flower
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class AddFlowerRequest : IRequest<AddFlowerResponse>
    {
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public int LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
        public int StockLevel { get; set; }
        public decimal? Price { get; set; }
    }
} 