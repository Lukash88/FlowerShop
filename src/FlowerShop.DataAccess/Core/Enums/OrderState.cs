using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum OrderState
    {
        [EnumMember(Value = "Pending")]
        Pending = 1,

        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,

        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed,

        [EnumMember(Value = "Shipped")]
        Shipped,

        [EnumMember(Value = "Completed")]
        Completed,

        [EnumMember(Value = "Cancelled")]
        Cancelled,

        [EnumMember(Value = "Expired")]
        Expired
    }
}