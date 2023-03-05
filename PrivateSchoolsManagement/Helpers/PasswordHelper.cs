using System.Security.Cryptography;

namespace PrivateSchoolsManagement.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // Generate a random salt value
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // Hash the password using Bcrypt with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            // Combine the salt and hash values into a single string
            string saltString = Convert.ToBase64String(salt);
            return $"{saltString}:{hashedPassword}";
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the salt value from the stored hash value
            string[] parts = hashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);

            // Hash the password using Bcrypt with the same salt
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            // Compare the resulting hash value with the stored hash value
            return hash == hashedPassword;
        }
    }
}
