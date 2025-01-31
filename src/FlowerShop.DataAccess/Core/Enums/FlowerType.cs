using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums;

public enum FlowerType
{
    [EnumMember(Value = "Real")]
    Real = 1,

    [EnumMember(Value = "Dried")]
    Dried,

    [EnumMember(Value = "Artificial")]
    Artificial
}