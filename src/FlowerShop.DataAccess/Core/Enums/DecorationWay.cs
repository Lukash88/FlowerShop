using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum DecorationWay
    {
        [EnumMember(Value = "None")]
        None,

        [EnumMember(Value = "LightlyDecorated")]
        LightlyDecorated,

        [EnumMember(Value = "ToRent")]
        RichlyDecorated
    }
}