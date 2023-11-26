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
        private const int MAXKEY = 26;

        public Cypher()
        {
            GenerateKey();
        }

        private int Key 
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
            int math;

            foreach(char c in encryptedText)
            {
                if (Char.IsDigit(c) || !Char.IsLetter(c))
                {
                    plaintext.Append(c);
                }
                else if (char.IsUpper(c))
                {
                    math = ((c - Key)-'A');
                    math = math<MINKEY? MAXKEY + math : math% MAXKEY;
                    math = math + 'A';
                    plaintext.Append(c == ' ' ? c : ((char)(math)));
                }
                else
                {
                    math = ((c - Key) - 'a');
                    math = math < MINKEY ? MAXKEY + math : math % MAXKEY;
                    math = math + 'a';
                    plaintext.Append(c == ' ' ? c : ((char)(math)));
                }
            }

            return plaintext.ToString();


        }

        public string Encrypt(string plaintext)
        {
            StringBuilder encryptedText = new StringBuilder();
            int math;
            foreach (char c in plaintext)
            {
                if (Char.IsDigit(c) || !Char.IsLetter(c))
                {
                    encryptedText.Append(c);
                }
                else if (char.IsUpper(c))
                {
                    math = (c+Key)-'A';
                    math = (math % MAXKEY) + 'A';
                    encryptedText.Append(c == ' ' ? c : ((char)(math)));
                }
                else
                {
                    math = (c + Key) - 'a';
                    math = (math % MAXKEY) + 'a';
                    encryptedText.Append( c == ' ' ?  c : ((char)(math)));
                }
                
                    
            }
            return encryptedText.ToString();
        }

        public void GenerateKey()
        {
            Random random = new Random();
            Key = random.Next(MINKEY,MAXKEY);
        }
    }
}
