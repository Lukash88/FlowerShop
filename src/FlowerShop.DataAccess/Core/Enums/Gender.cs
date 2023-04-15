using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,

        [EnumMember(Value = "Female")]
        Female,

        [EnumMember(Value = "Other")]
        Other       
    }
}