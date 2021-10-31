namespace FlowerShop.ApplicationServices.API.Domain.Bouquet
{
    using FlowerShop.DataAccess.Enums;
    using MediatR;

    public class UpdateBouquetRequest : IRequest<UpdateBouquetResponse>
    {
        public int BouquetId;
        public Occassion Occasion { get; set; }
        public TypeOfFlowerArrangement TypeOfArrangement { get; set; }
        public int Quantity { get; set; }
        public DecorationWay DecorationWay { get; set; }
    }
}
