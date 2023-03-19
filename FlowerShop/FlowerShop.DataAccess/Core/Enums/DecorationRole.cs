using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum DecorationRole
    {
        [EnumMember(Value = "ToRent")]
        ToRent = 1,

        [EnumMember(Value = "ToBuy")]
        ToBuy
    }
}