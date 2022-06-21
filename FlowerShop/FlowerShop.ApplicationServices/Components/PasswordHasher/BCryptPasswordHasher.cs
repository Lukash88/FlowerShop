using Microsoft.AspNetCore.Identity;

namespace FlowerShop.ApplicationServices.Components.PasswordHasher
{
    public class BCryptPasswordHasher<User> : IPasswordHasher<User> where User : class
    {
        
        public string HashPassword(User user, string password)
        {  
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

            if (isValid && BCrypt.Net.BCrypt.PasswordNeedsRehash(hashedPassword, 12))
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }

            return isValid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}