namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class AddDecorationRequest : IRequest<AddDecorationResponse>
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
