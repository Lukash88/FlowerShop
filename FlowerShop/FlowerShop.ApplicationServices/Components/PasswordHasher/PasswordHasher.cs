using FlowerShop.DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Cryptography;


namespace FlowerShop.ApplicationServices.Components.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        
        public string HashPassword(User user, string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));            

            return hashed;  
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
           //hashedPassword = user.PasswordHash;

           if (!hashedPassword.Equals(providedPassword))
           {
                return PasswordVerificationResult.Failed;
           }

            return PasswordVerificationResult.Success;
        }


        //user.passwordHash = hashed;
        //user.passwordSalt = Convert.ToBase64String(salt);
    }
}
