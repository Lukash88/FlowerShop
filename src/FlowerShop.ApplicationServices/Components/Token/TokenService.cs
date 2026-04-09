using FlowerShop.DataAccess.Core.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowerShop.ApplicationServices.Components.Token;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    private readonly string _issuer;

    public TokenService(IConfiguration config)
    {
        var tokenKey = config["Token:Key"] 
            ?? throw new InvalidOperationException("Token:Key not configured");
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        _issuer = config["Token:Issuer"] 
            ?? throw new InvalidOperationException("Token:Issuer not configured");
    }

    public string CreateToken(AppUser user, IList<string> userRoles)
    {
        var claimsList = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(ClaimTypes.GivenName, user.FirstName ?? string.Empty),
            new(ClaimTypes.Surname, user.LastName ?? string.Empty)
        };

        foreach (var roleName in userRoles)
        {
            claimsList.Add(new Claim(ClaimTypes.Role, roleName));
        }

        var signingCreds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claimsList),            
            // 7 days set only for development
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = signingCreds,
            Issuer = _issuer
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(descriptor);

        return tokenHandler.WriteToken(token);
    }
}