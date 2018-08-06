using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class HexadecimalColorGenerator
    {

        static HexadecimalColorGenerator()
        {
            rand = new Random();
        }
        public static Random rand;

        /// <summary>
        /// Generates a random string representing a color in hexadecimal format
        /// </summary>
        /// <returns>Hexadecimal color in the format #AAAAAA</returns>
        public static string Generate()
        {
            byte[] buffer = new byte[3];
            rand.NextBytes(buffer);

            string[] hexBuffer = buffer.Select(b => b.ToString("x2")).ToArray();

            return $"#{string.Join(string.Empty, hexBuffer)}";
        }


    }
}
