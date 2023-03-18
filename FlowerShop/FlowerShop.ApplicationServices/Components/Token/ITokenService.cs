using FlowerShop.DataAccess.Core.Entities.Identity;

namespace FlowerShop.ApplicationServices.Components.Token
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}