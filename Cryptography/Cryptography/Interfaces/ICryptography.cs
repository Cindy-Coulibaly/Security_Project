using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Interfaces
{
    internal interface ICryptography
    {
        public string Encrypt(string plaintext);
        public string Decrypt(string encryptedText);
        public void GenerateKey();
    }
}
