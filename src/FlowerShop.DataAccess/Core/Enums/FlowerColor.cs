using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums;

public enum FlowerColor
{
    [EnumMember(Value = "Red")]
    Red = 1,

    [EnumMember(Value = "Pink")]
    Pink,

    [EnumMember(Value = "Purple")]
    Purple,

    [EnumMember(Value = "Orange")]
    Orange,

    [EnumMember(Value = "Yellow")]
    Yellow,

    [EnumMember(Value = "White")]
    White,

    [EnumMember(Value = "Blue")]
    Blue,

    [EnumMember(Value = "Lavender")]
    Lavender,

    [EnumMember(Value = "Green")]
    Green,

    [EnumMember(Value = "Black")]
    Black
}