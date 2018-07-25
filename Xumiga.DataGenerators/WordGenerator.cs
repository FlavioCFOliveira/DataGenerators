using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class WordGenerator
    {
        private const string VOWEL_CHARS = @"aeiou";
        private const string CONSONANT_CHARS = @"bcdfghjklmnpqrstvwxyz";

        static WordGenerator()
        {
            rand = new Random();
        }

        public static Random rand;

        public static string[] GenerateWords(int numberOfWords)
        {
            var result = new string[numberOfWords];

            for (int i = 0; i < numberOfWords; i++)
            {
                result[i] = GenerateWord(rand.Next(2, 12));
            }

            return result;
        }
        public static string[] GenerateWords(int numberOfWords, int minOutputSize, int maxOutputSize)
        {
            var result = new string[numberOfWords];

            for (int i = 0; i < numberOfWords; i++)
            {
                result[i] = GenerateWord(minOutputSize, maxOutputSize);
            }

            return result;
        }

        public static string GenerateWord(int minOutputSize, int maxOutputSize)
        {
            return GenerateWord(rand.Next(minOutputSize, maxOutputSize));
        }
        public static string GenerateWord(int outputSize)
        {
            string result = string.Empty;

            int currentCharType = rand.Next(0, 1);

            while (result.Length < outputSize)
            {
                int ammout = rand.Next(1, 2);

                for (int i = 0; i < ammout; i++)
                {
                    if (currentCharType == 0) { result += VOWEL_CHARS[rand.Next(VOWEL_CHARS.Length)]; }
                    if (currentCharType == 1) { result += CONSONANT_CHARS[rand.Next(CONSONANT_CHARS.Length)]; }
                }

                currentCharType = (currentCharType == 0) ? 1 : 0;
            }

            if (result.Length > outputSize)
            {
                result = result.Substring(0, outputSize);
            }

            return result;
        }

    }
}
