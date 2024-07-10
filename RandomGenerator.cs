using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Game
{

    internal class RandomGenerator
    {
        private Random RandomNumber { get; }
        public RandomGenerator()
        {
            RandomNumber = new Random();
        }

        public int GetRandomNumber(int L, int R)
        {
            return RandomNumber.Next(L, R);
        }

        public byte[] GetRandomKey(int length)
        {
            byte[] key = new byte[length];
            RandomNumberGenerator.Fill(key);
            return key;
        }


        public string GetHMAC(string message, byte[] key)
        {
            using (var hmacsha3 = new HMACSHA256(key))
            {
                var hash = hmacsha3.ComputeHash(Encoding.UTF8.GetBytes(message));
                return Convert.ToHexString(hash);
            }
        }

    }
}
