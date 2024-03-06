using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum TypeOfFlowerArrangement
    {
        [EnumMember(Value = "Circular")]
        Circular = 1,

        [EnumMember(Value = "Oval")]
        Oval,

        [EnumMember(Value = "Basket")]
        Basket,

        [EnumMember(Value = "FlowerBox")]
        FlowerBox,

        [EnumMember(Value = "Elliptical")]
        Elliptical,

        [EnumMember(Value = "Horizontal")]
        Horizontal,

        [EnumMember(Value = "Vertical")]
        Vertical,

        [EnumMember(Value = "Triangular")]
        Triangular,

        [EnumMember(Value = "Cascade")]
        Cascade,

        [EnumMember(Value = "HandTied")]
        HandTied,

        [EnumMember(Value = "Biedermeier")]
        Biedermeier,

        [EnumMember(Value = "Nosegay")]
        Nosegay,

        [EnumMember(Value = "Posy")]
        Posy,

        [EnumMember(Value = "WristCorsage")]
        WristCorsage,

        [EnumMember(Value = "Crescent")]
        Crescent,

        [EnumMember(Value = "SingleStem")]
        SingleStem
    }
}