using Cryptography.Models;

namespace Cryptography
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cypher cypher = new Cypher();

            Console.WriteLine(cypher.Encrypt("Cindy 33"));
            Console.WriteLine(cypher.Decrypt(cypher.Encrypt("Cindy 33")));

        }
    }
}