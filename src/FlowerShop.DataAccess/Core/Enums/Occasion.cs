using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums;

public enum Occasion
{
    [EnumMember(Value = "Birthday")]
    Birthday = 1,

    [EnumMember(Value = "NameDay")]
    NameDay,

    [EnumMember(Value = "Sympathy")]
    Sympathy,

    [EnumMember(Value = "JustBecause")]
    JustBecause,

    [EnumMember(Value = "GetWellSoon")]
    GetWellSoon,

    [EnumMember(Value = "NewBaby")]
    NewBaby,

    [EnumMember(Value = "Congratulations")]
    Congratulations,

    [EnumMember(Value = "Anniversary")]
    Anniversary,

    [EnumMember(Value = "Romantic")]
    Romantic,

    [EnumMember(Value = "Engagement")]
    Engagement,

    [EnumMember(Value = "Wedding")]
    Wedding,

    [EnumMember(Value = "Leaving")]
    Leaving,

    [EnumMember(Value = "NewHome")]
    NewHome,

    [EnumMember(Value = "ThankYou")]
    ThankYou,

    [EnumMember(Value = "Halloween")]
    Halloween,

    [EnumMember(Value = "Apology")]
    Apology,

    [EnumMember(Value = "Valentine")]
    Valentine,

    [EnumMember(Value = "WomensDay")]
    WomensDay,

    [EnumMember(Value = "MothersDay")]
    MothersDay,

    [EnumMember(Value = "FathersDay")]
    FathersDay,

    [EnumMember(Value = "GrannysDay")]
    GrannysDay,

    [EnumMember(Value = "GrandadysDay")]
    GrandadysDay,

    [EnumMember(Value = "Easter")]
    Easter,

    [EnumMember(Value = "XMas")]
    XMas,

    [EnumMember(Value = "Funeral")]
    Funeral
}