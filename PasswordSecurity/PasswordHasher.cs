using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordSecurity
{
    public class PasswordHasher
    {
        public string GetPasswordHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashResult = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hashResult;
            }
        }
    }
}