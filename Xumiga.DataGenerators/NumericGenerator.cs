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
            return rand.Next(maxValue + 1);
        }
        public static int GenerateInteger(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue + 1);
        }


        public static byte GenerateByte()
        {
            byte[] r = new byte[1];
            rand.NextBytes(r);

            return r[0];
        }

        public static long GenerateLong()
        {
            return rand.NextLong();
        }
        public static long GenerateLong(long max)
        {
            return rand.NextLong(max);
        }
        public static long GenerateLong(long min, long max)
        {
            return rand.NextLong(min, max);
        }
        public static short GenerateShort(short minValue, short maxValue)
        {
            return (short)rand.Next((int)minValue, (int)maxValue);
        }

        public static decimal GenerateDecimal(int precision, int scale)
        {
            if (precision == 0) throw new Exception("precision must be greater than zero.");
            if (precision == scale) throw new Exception("precision and scale must have different values");
            if (precision < scale) throw new Exception("precision cannot be less than scale");

            int randPrecision = NumericGenerator.GenerateInteger(1, (precision - scale) + 1);
            var a = StringGenerator.GetNumeric(randPrecision);

            int randScale = NumericGenerator.GenerateInteger(1, scale + 1);
            var b = StringGenerator.GetNumeric(randScale);

            decimal result = decimal.Parse($"{a}.{b}");

            return result;
        }
    }
}
