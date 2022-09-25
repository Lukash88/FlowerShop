
namespace FlowerShop.DataAccess.Enums
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        Pot = 1,
        Ribbon,
        Foam,
        Basket
    }
}