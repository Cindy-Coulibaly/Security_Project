using Cryptography.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptography.Models
{
    internal class RSA : ICryptography
    {
        private RSACryptoServiceProvider provider;

        public RSA()
        {
            GenerateKey();
        }

        public string Decrypt(string encryptedText)
        {
            //Gets the bytes back from the string it was formatted to
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            //Decrypts the bytes using the generated private key, uses OAEP padding (only avaliable on Windows XP and later)
            byte[] decryptedTextBytes = provider.Decrypt(encryptedTextBytes, true);

            string decryptedText = Encoding.UTF8.GetString(decryptedTextBytes);


            return decryptedText;
        }

        public string Encrypt(string plaintext)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plaintext);

            //Encrypts the bytes using the generated public key, uses OAEP padding (only avaliable on Windows XP and later)
            byte[] encryptedBytes = provider.Encrypt(plainTextBytes, true);
            //Formats the string in a way that can be converted back from later, using Encoding.UTF8.GetString was being unreliable
            string encryptedString = Convert.ToBase64String(encryptedBytes);


            return encryptedString;
        }

        public void GenerateKey()
        {
            //Creates a new instance of RSACryptoServiceProvider and generates it's public and private keys
            provider = new RSACryptoServiceProvider();
        }
    }
}
