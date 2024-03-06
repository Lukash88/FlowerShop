using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        [EnumMember(Value = "Pot")]
        Pot = 1,

        [EnumMember(Value = "Ribbon")]
        Ribbon,

        [EnumMember(Value = "Foam")]
        Foam,

        [EnumMember(Value = "Basket")]
        Basket
    }
}