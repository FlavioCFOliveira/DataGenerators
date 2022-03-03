using System;
using System.Linq;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random words generator
/// </summary>
public static class WordGenerator
{
    private const string VOWEL_CHARS = @"aeiou";
    private const string CONSONANT_CHARS = @"bcdfghjklmnpqrstvwxyz";

    private static Random rand;
    static WordGenerator()
    {
        rand = new Random();
    }

    /// <summary>
    /// Generate a array of words
    /// </summary>
    /// <param name="numberOfWords">how many words are pretended</param>
    /// <param name="capitalFirstLetter">start with a capital letter</param>
    /// <returns></returns>
    public static string[] GenerateWords(int numberOfWords, bool capitalFirstLetter = false)
    {
        var result = new string[numberOfWords];

        for (int i = 0; i < numberOfWords; i++)
        {
            result[i] = GenerateWord(rand.Next(2, 12), capitalFirstLetter);
        }

        return result;
    }

    /// <summary>
    /// Generate a array of words
    /// </summary>
    /// <param name="numberOfWords">how many words are pretended</param>
    /// <param name="minOutputSize">word minnimal size</param>
    /// <param name="maxOutputSize">word maximum size</param>
    /// <param name="capitalFirstLetter">start with a capital letter</param>
    /// <returns></returns>
    public static string[] GenerateWords(int numberOfWords, int minOutputSize, int maxOutputSize, bool capitalFirstLetter = false)
    {
        var result = new string[numberOfWords];

        for (int i = 0; i < numberOfWords; i++)
        {
            result[i] = GenerateWord(minOutputSize, maxOutputSize, capitalFirstLetter);
        }

        return result;
    }

    /// <summary>
    /// Generate a dynamic sequence of characteres like a word
    /// </summary>
    /// <param name="minOutputSize">characters sequence minimum size</param>
    /// <param name="maxOutputSize">characters sequence maximum size</param>
    /// <param name="capitalFirstLetter">start with a capital letter</param>
    /// <returns></returns>
    public static string GenerateWord(int minOutputSize, int maxOutputSize, bool capitalFirstLetter = false)
    {
        return GenerateWord(rand.Next(minOutputSize, maxOutputSize), capitalFirstLetter);
    }

    /// <summary>
    /// Generate a fixed sequence of characteres like a word
    /// </summary>
    /// <param name="outputSize">the size of the characters sequence</param>
    /// <param name="capitalFirstLetter">start with a capital letter</param>
    /// <returns></returns>
    public static string GenerateWord(int outputSize, bool capitalFirstLetter = false)
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

        if (capitalFirstLetter)
        {
            result = result.First().ToString().ToUpper() + result.Substring(1);
        }

        return result;
    }

}