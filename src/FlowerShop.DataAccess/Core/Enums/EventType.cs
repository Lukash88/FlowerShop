using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums;

public enum EventType
{
    [EnumMember(Value = "Birthday")]
    Birthday = 1,

    [EnumMember(Value = "BabyShower")]
    BabyShower,

    [EnumMember(Value = "Baptism")]
    Baptism,

    [EnumMember(Value = "BrandOfProductLaunch")]
    BrandOfProductLaunch,

    [EnumMember(Value = "InternalCompanyMeeting")]
    InternalCompanyMeeting,

    [EnumMember(Value = "Congratulations")]
    Congratulations,

    [EnumMember(Value = "Anniversary")]
    Anniversary,

    [EnumMember(Value = "Romantic")]
    Romantic,

    [EnumMember(Value = "JustBecause")]
    JustBecause,

    [EnumMember(Value = "PrivateParty")]
    PrivateParty,

    [EnumMember(Value = "Engagement")]
    Engagement,

    [EnumMember(Value = "CivilWedding")]
    CivilWedding,

    [EnumMember(Value = "ChurchWedding")]
    ChurchWedding,

    [EnumMember(Value = "WeddingParty")]
    WeddingParty,

    [EnumMember(Value = "NewHome")]
    NewHome,

    [EnumMember(Value = "ThankYou")]
    ThankYou,

    [EnumMember(Value = "Halloween")]
    Halloween,

    [EnumMember(Value = "Funeral")]
    Funeral
}