using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums;

public enum ReservationState
{
    [EnumMember(Value = "Pending")]
    Pending = 1,

    [EnumMember(Value = "Processing")]
    Processing,

    [EnumMember(Value = "Confirmed")]
    Confirmed,

    [EnumMember(Value = "Cancelled")]
    Cancelled,

    [EnumMember(Value = "Expired")]
    Expired
}