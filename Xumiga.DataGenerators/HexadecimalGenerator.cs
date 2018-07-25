using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class HexadecimalGenerator
    {
        static HexadecimalGenerator()
        {
            rand = new Random();
        }

        public static Random rand;
        private const string HEXA_CHARS = @"0123456789ABCDEF";

        /// <summary>
        /// Generates a string with random Hexadecimal Random chars
        /// </summary>
        /// <param name="outputSize">Output string size</param>
        /// <returns></returns>
        public static string Generate(int outputSize)
        {
            var outputChars = new char[outputSize];
            for (int i = 0; i < outputSize; i++)
            {
                outputChars[i] = HEXA_CHARS[rand.Next(HEXA_CHARS.Length)];
            }

            return new string(outputChars);
        }

    }
}
