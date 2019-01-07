using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class NumericGenerator
    {
        static NumericGenerator()
        {
            rand = new Random();
        }

        public static Random rand;

        public static int GenerateInteger()
        {
            return rand.Next();
        }
        public static int GenerateInteger(int maxValue)
        {
            return rand.Next(maxValue);
        }
        public static int GenerateInteger(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }


    }
}
