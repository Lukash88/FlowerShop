using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum ReservationStateEnum
    {
        [EnumMember(Value = "Active")]
        Active = 1,

        [EnumMember(Value = "Cancelled")]
        Cancelled,

        [EnumMember(Value = "Expired")]
        Expired,

        [EnumMember(Value = "Processing")]
        Processing
    }
}