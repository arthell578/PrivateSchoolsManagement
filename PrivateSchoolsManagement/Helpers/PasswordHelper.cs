using System.Security.Cryptography;

namespace PrivateSchoolsManagement.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password, out byte[] salt)
        {
            // Generate a random salt value
            salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // Hash the password using Bcrypt with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.SaltRevision.Revision2B, salt);

            return hashedPassword;
        }
        public static bool VerifyPassword(string password, string hashedPassword, byte[] salt)
        {
            // Hash the password using Bcrypt with the same salt
            string hash = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.SaltRevision.Revision2B, salt);

            // Compare the resulting hash value with the stored hash value
            return hash == hashedPassword;
        }
    }
}
