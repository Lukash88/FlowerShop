namespace FlowerShop.ApplicationServices.API.Domain.Decoration
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class UpdateDecorationRequest : IRequest<UpdateDecorationResponse>
    {
        public int DecorationId;
        public string Name { get; set; }
        public string Description { get; set; }
        public DecorationRole Role { get; set; }
        public bool IsAvailable { get; set; }
        public decimal? Price { get; set; }
        public int StockLevel { get; set; }
    }
}