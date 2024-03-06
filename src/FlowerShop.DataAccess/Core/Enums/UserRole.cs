using System.Runtime.Serialization;

namespace FlowerShop.DataAccess.Core.Enums
{
    public enum UserRole
    {
        [EnumMember(Value = "Admin")]
        Admin = 1,

        [EnumMember(Value = "Employee")]
        Employee,

        [EnumMember(Value = "Client")]
        Client
    }
}