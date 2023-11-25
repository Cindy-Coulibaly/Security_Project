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
        private const int MINKEY = -26;
        private const int MAXKEY = -26;

        public Cypher()
        {
            
        }
        public Cypher(int key)
        {
            Key = key;
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
                if (char.IsUpper(c))
                {
                    plaintext.Append(c == ' ' ? c : char.ToUpper((char)(char.ToLower(c) - Key)));
                }
                else
                {
                    plaintext.Append(c == ' ' ? c : c - Key);
                }
            }

            return plaintext.ToString();


        }

        public string Encrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plaintext)
            {
                if (char.IsUpper(c))
                {
                    encryptedText.Append(c == ' ' ? c : char.ToUpper((char)(char.ToLower(c) + Key)));
                }
                else
                {
                    encryptedText.Append( c == ' ' ? c : c+Key);
                }
                
                    
            }
            return encryptedText.ToString();
        }

        public void GenerateKey()
        {
            // let the user input a key, it's definitly not random
            throw new NotImplementedException();
        }
    }
}
