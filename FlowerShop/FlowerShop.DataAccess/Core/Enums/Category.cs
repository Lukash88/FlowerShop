using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FlowerShop.DataAccess.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        Pot = 1,
        Ribbon,
        Foam,
        Basket
    }
}