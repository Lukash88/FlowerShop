using FlowerShop.DataAccess.CQRS;
using FlowerShop.DataAccess.CQRS.Queries.User;
using FlowerShop.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FlowerShop.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher<User> passwordHasher;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, 
            IQueryExecutor queryExecutor, IPasswordHasher<User> passwordHasher)
            : base(options, logger, encoder, clock)
        {
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            User user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var providedPassword = passwordHasher.HashPassword(user, credentials[1]);
                var query = new GetUserQuery()
                {
                    UserName = username
                };
                user = await this.queryExecutor.Execute(query);

                //byte[] salt = new byte[128 / 8];
                //using (var rng = RandomNumberGenerator.Create())
                //{
                //    rng.GetBytes(salt);
                //}

                passwordHasher.HashPassword(user, providedPassword);

                passwordHasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword);

                //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                //    password : user.Password,
                //    salt: salt,
                //    prf: KeyDerivationPrf.HMACSHA1,
                //    iterationCount: 10000,
                //    numBytesRequested: 256 / 8));


                if (user == null || user.PasswordHash != providedPassword)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            
            return AuthenticateResult.Success(ticket);
        }
    }
}
