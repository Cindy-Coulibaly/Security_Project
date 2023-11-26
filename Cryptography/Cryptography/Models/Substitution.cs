using Cryptography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    internal class Substitution : ICryptography
    {
        private Dictionary<char, char> key = new Dictionary<char, char>();

        public Substitution()
        {
            GenerateKey();
        }

        public string Decrypt(string encryptedText)
        {
            StringBuilder sb = new StringBuilder();

            char[] chars = encryptedText.ToCharArray();

            foreach (char c in chars)
            {
                foreach (char k in key.Keys)
                {
                    if (key[k] == c)
                    {
                        sb.Append(k);
                    }
                }
            }

            return sb.ToString();
        }

        public string Encrypt(string plaintext)
        {
            StringBuilder sb = new StringBuilder();

            char[] chars = plaintext.ToLower().ToCharArray();

            foreach (char c in chars)
            {
                sb.Append(key[c]);
            }

            return sb.ToString();
        }

        public void GenerateKey()
        {
            Random rand = new Random();

            List<char> characters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ' };
            List<char> randomized = characters.OrderBy(_ => rand.Next()).ToList();

            for (int i = 0; i < randomized.Count; i++)
            {
                key[characters[i]] = randomized[i];
            }

        }
    }
}
