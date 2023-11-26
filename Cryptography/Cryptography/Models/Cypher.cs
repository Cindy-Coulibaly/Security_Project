using Cryptography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Models
{
    internal class Cypher : ICryptography
    {
        private int _key;
        private const int MINKEY = 0;
        private const int MAXKEY = 25;

        public Cypher()
        {
            GenerateKey();
        }

        public int Key 
        {
            get
            {
                return _key;
            }
            set
            {
                if(value>MAXKEY && value < MINKEY)
                {
                    throw new ArgumentException("you can't cypher more then 26 and less then -26 ");
                }
                _key = value;
            }
        }
        public string Decrypt(string encryptedText)
        {
            StringBuilder plaintext = new StringBuilder();

            foreach(char c in encryptedText)
            {
                if (Char.IsDigit(c))
                {
                    plaintext.Append(c);
                } 
                else if (char.IsUpper(c))
                {
                    plaintext.Append(c == ' ' ? c : (char)((((c - Key) - 'A') % 26) + 'A'));
                }
                else
                {
                    plaintext.Append(c == ' ' ? c : (char)((((c - Key) - 'a') % 26) + 'a'));
                }
            }

            return plaintext.ToString();


        }

        public string Encrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plaintext)
            {
                if (Char.IsDigit(c))
                {
                    encryptedText.Append(c);
                }
                else if (char.IsUpper(c))
                {
                    encryptedText.Append(c == ' ' ? c : (char)((((c + Key) - 'A') % 26) + 'A'));
                }
                else
                {
                    encryptedText.Append( c == ' ' ?  c : (char)((((c + Key) - 'a') % 26) + 'a'));
                }
                
                    
            }
            return encryptedText.ToString();
        }

        public void GenerateKey()
        {
            Random random = new Random();
            Key = random.Next(MINKEY,MAXKEY);
            Console.WriteLine(Key);
        }
    }
}
