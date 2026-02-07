using System;
using System.Security.Cryptography;

namespace CrudLeads.Infrastructure.Security
{
    public static class PasswordHelper
    {
        private const int SaltSize = 32;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public static void HashPassword(string password, out string hash, out string salt)
        {
            var saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);
            var hashBytes = ComputeHash(password, saltBytes);
            hash = Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var hashBytes = ComputeHash(password, saltBytes);
            var computedHash = Convert.ToBase64String(hashBytes);
            return storedHash == computedHash;
        }

        private static byte[] ComputeHash(string password, byte[] salt)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                return deriveBytes.GetBytes(HashSize);
            }
        }
    }
}
