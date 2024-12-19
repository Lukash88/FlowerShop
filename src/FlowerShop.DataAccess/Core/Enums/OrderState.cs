using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum OrderState
    {
        [EnumMember(Value = "Pending")]
        Pending = 1,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed,

        [EnumMember(Value = "Payment Mismatch")]
        PaymentMismatch,

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