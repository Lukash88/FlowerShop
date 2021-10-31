namespace FlowerShop.ApplicationServices.API.Domain.Models
{
    using FlowerShop.DataAccess.Enums;

    public class FlowerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FlowerType FlowerType { get; set; }
        public string Description { get; set; }
        public byte LengthInCm { get; set; }
        public FlowerColour Colour { get; set; }
    }
}
