using System;
using System.Text;

namespace Zadatak_1.Helper
{
    class Encryption
    {
        /// <summary>
        /// This method encrypts forwarded string.
        /// </summary>
        /// <param name="password">String to be encrypted.</param>
        /// <returns>Encrypted string.</returns>
        public static string EncryptPassword(string password)
        {
            byte[] b = Encoding.UTF8.GetBytes(password);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}