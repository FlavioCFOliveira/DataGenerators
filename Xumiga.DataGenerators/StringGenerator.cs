using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingTools
{
    public static class StringGenerator
    {
        private const string FULL_CHARS = @"qwertyuiopasdfghjklzxcvbnm0123456789QWERTYUIOPASDFGHJKLZXCVBNM@£§€{[]}|\!#$%&/()=?»*ªº/-_<>'~^.""";
        private const string ALPHANUMERIC_CHARS = "qwertyuiopasdfghjklzxcvbnm0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string ALPHABETIC_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private const string ALPHABETIC_UPPER_CHARS = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string ALPHABETIC_LOWER_CHARS = "qwertyuiopasdfghjklzxcvbnm";
        private const string NUMERIC_CHARS = "0123456789";
        private const string SYMBOL_CHARS = @"@£§€{[]}|\!#$%&/()=?»*ªº/-_<>'~^.""";

        static StringGenerator()
        {
            rand = new Random();
        }

        public static Random rand;

        public static string GetFromSource(int outputSize, string sourceChars)
        {
            var outputChars = new char[outputSize];
            for (int i = 0; i < outputSize; i++)
            {
                outputChars[i] = sourceChars[rand.Next(sourceChars.Length)];
            }

            return new string(outputChars);
        }

        public static string GetAlphaNumeric(int outputSize)
        {
            return GetFromSource(outputSize, ALPHANUMERIC_CHARS);
        }
        public static string GetAlphaNumericWithSymbols(int outputSize)
        {
            return GetFromSource(outputSize, FULL_CHARS);
        }
        public static string GetNumeric(int outputSize)
        {
            return GetFromSource(outputSize, NUMERIC_CHARS);
        }
        public static string GetSymbols(int outputSize)
        {
            return GetFromSource(outputSize, SYMBOL_CHARS);
        }
        public static string GetAlphabeticUpper(int outputSize)
        {
            return GetFromSource(outputSize, ALPHABETIC_UPPER_CHARS);
        }
        public static string GetAlphabeticLower(int outputSize)
        {
            return GetFromSource(outputSize, ALPHABETIC_LOWER_CHARS);
        }
        public static string GetAlphabetic(int outputSize)
        {
            return GetFromSource(outputSize, ALPHABETIC_CHARS);
        }




        public static string GetAlphaNumeric(int minSize, int maxSize)
        {
            return GetAlphaNumeric(rand.Next(minSize, maxSize));
        }
        public static string GetAlphaNumericWithSymbols(int minSize, int maxSize)
        {
            return GetAlphaNumericWithSymbols(rand.Next(minSize, maxSize));
        }
        public static string GetNumeric(int minSize, int maxSize)
        {
            return GetNumeric(rand.Next(minSize, maxSize));
        }
        public static string GetSymbols(int minSize, int maxSize)
        {
            return GetSymbols(rand.Next(minSize, maxSize));
        }
        public static string GetAlphabeticUpper(int minSize, int maxSize)
        {
            return GetAlphabeticUpper(rand.Next(minSize, maxSize));
        }
        public static string GetAlphabeticLower(int minSize, int maxSize)
        {
            return GetAlphabeticLower(rand.Next(minSize, maxSize));
        }
        public static string GetAlphabetic(int minSize, int maxSize)
        {
            return GetAlphabetic(rand.Next(minSize, maxSize));
        }


        public static string GenerateStrongString(int size, int minNumbers = 0, int minUpperChars = 0, int minLowerChars = 0, int minSymbolChars = 0)
        {
            var minRequiredTotal = (minNumbers + minUpperChars + minLowerChars + minSymbolChars);
            if (size < minRequiredTotal) throw new ArgumentException("Size must be greater than the sum of all minimum char parameters");

            List<string> tmp = new List<string>();

            if (minNumbers > 0) { tmp.Add(GetNumeric(minNumbers)); }
            if (minUpperChars > 0) { tmp.Add(GetAlphabeticUpper(minUpperChars)); }
            if (minLowerChars > 0) { tmp.Add(GetAlphabeticLower(minLowerChars)); }
            if (minSymbolChars > 0) { tmp.Add(GetSymbols(minSymbolChars)); }

            // random filler
            var fillingSize = (size - minRequiredTotal);
            if (fillingSize > 0) { tmp.Add(GetAlphaNumeric(fillingSize)); }

            string joined = string.Join("", tmp);

            string shuffled = new string(joined.ToCharArray().OrderBy(o => rand.Next()).ToArray());

            return shuffled;
        }

        /// <summary>
        /// Geta a random string using a mask to specify the alfabetica and numeric Chars example "XAANNXAANANNANANA"
        /// A - Alfabetic [A-Z], N - Numeric [0-9], X - Alfanumeric[A-Z0-9] 
        /// </summary>
        /// <param name="mask">The mast</param>
        /// <returns></returns>
        public static string GetMaskedAlphaNumeric(string mask)
        {
            if (!string.IsNullOrEmpty(mask))
            {
                var result = new char[mask.Length];
                for (int i = 0; i < mask.Length; i++)
                {
                    switch (mask[i])
                    {
                        case 'a': result[i] = GetAlphabeticLower(1)[0]; break;
                        case 'A': result[i] = GetAlphabeticUpper(1)[0]; break;
                        case 'n': result[i] = GetNumeric(1)[0]; break;
                        case 'N': result[i] = GetNumeric(1)[0]; break;
                        case 'X': result[i] = GetAlphaNumeric(1)[0]; break;
                        case 'x': result[i] = GetAlphaNumeric(1)[0]; break;
                        default: result[i] = mask[i]; break;
                    }
                }
                return new string(result);
            }

            return string.Empty;
        }
    }
}
