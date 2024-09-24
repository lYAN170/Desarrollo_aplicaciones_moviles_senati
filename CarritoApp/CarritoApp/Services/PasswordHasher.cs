using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarritoApp.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20; 
        private const int Iterations = 10000;

        public string HashPassword(string password)
        {
            using var rng = new RNGCryptoServiceProvider();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            var saltedHash = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, saltedHash, 0, SaltSize);
            Array.Copy(hash, 0, saltedHash, SaltSize, HashSize);

            return Convert.ToBase64String(saltedHash);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var saltedHash = Convert.FromBase64String(hashedPassword);

            var salt = new byte[SaltSize];
            var hash = new byte[HashSize];
            Array.Copy(saltedHash, 0, salt, 0, SaltSize);
            Array.Copy(saltedHash, SaltSize, hash, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var newHash = pbkdf2.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hash[i] != newHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

