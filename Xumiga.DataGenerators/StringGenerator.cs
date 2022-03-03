using System;
using System.Collections.Generic;
using System.Linq;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator for character sequences
/// </summary>
public static class StringGenerator
{
    private const string FULL_CHARS = @"qwertyuiopasdfghjklzxcvbnm0123456789QWERTYUIOPASDFGHJKLZXCVBNM@£§€{[]}|\!#$%&/()=?»*ªº/-_<>'~^.""";
    private const string ALPHANUMERIC_CHARS = "qwertyuiopasdfghjklzxcvbnm0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
    private const string ALPHABETIC_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
    private const string ALPHABETIC_UPPER_CHARS = "QWERTYUIOPASDFGHJKLZXCVBNM";
    private const string ALPHABETIC_LOWER_CHARS = "qwertyuiopasdfghjklzxcvbnm";
    private const string NUMERIC_CHARS = "0123456789";
    private const string SYMBOL_CHARS = @"@£§€{[]}|\!#$%&/()=?»*ªº/-_<>'~^.""";
    private static readonly Random rand;

    static StringGenerator()
    {
        rand = new Random();
    }

    /// <summary>
    /// returns a random sequence of characters based on a source string
    /// </summary>
    /// <param name="outputSize">output sequence size</param>
    /// <param name="sourceChars">string containing all the chars to be used</param>
    /// <returns></returns>
    public static string GetFromSource(int outputSize, string sourceChars)
    {
        return string.Create(outputSize, string.Empty, (span, v) =>
        {
            for (int i = 0; i < outputSize; i++)
            {
                span[i] = sourceChars[rand.Next(sourceChars.Length)];
            }
        });
    }

    /// <summary>
    /// returns a random sequence of letters and numbers 
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetAlphaNumeric(int outputSize)
    {
        return GetFromSource(outputSize, ALPHANUMERIC_CHARS);
    }

    /// <summary>
    /// returns a random sequence of letters, numbers and symbols 
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetAlphaNumericWithSymbols(int outputSize)
    {
        return GetFromSource(outputSize, FULL_CHARS);
    }

    /// <summary>
    /// returns a random sequence of numbers
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetNumeric(int outputSize)
    {
        return GetFromSource(outputSize, NUMERIC_CHARS);
    }

    /// <summary>
    /// returns a random sequence of symbols
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetSymbols(int outputSize)
    {
        return GetFromSource(outputSize, SYMBOL_CHARS);
    }

    /// <summary>
    /// returns a random sequence of letters in uppercase
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetAlphabeticUpper(int outputSize)
    {
        return GetFromSource(outputSize, ALPHABETIC_UPPER_CHARS);
    }

    /// <summary>
    /// returns a random sequence of letters in lowercase 
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetAlphabeticLower(int outputSize)
    {
        return GetFromSource(outputSize, ALPHABETIC_LOWER_CHARS);
    }

    /// <summary>
    /// returns a random sequence of letters upper and lowe case 
    /// </summary>
    /// <param name="outputSize"></param>
    /// <returns></returns>
    public static string GetAlphabetic(int outputSize)
    {
        return GetFromSource(outputSize, ALPHABETIC_CHARS);
    }

    /// <summary>
    /// returns a random sequence of numbers 
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetAlphaNumeric(int minSize, int maxSize)
    {
        return GetAlphaNumeric(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of letters, numbers or symbols 
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetAlphaNumericWithSymbols(int minSize, int maxSize)
    {
        return GetAlphaNumericWithSymbols(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of munbers 
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetNumeric(int minSize, int maxSize)
    {
        return GetNumeric(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of symbols 
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetSymbols(int minSize, int maxSize)
    {
        return GetSymbols(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of letters in upper case 
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetAlphabeticUpper(int minSize, int maxSize)
    {
        return GetAlphabeticUpper(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of letters in lower case
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetAlphabeticLower(int minSize, int maxSize)
    {
        return GetAlphabeticLower(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of letters in upper and lower case
    /// </summary>
    /// <param name="minSize"></param>
    /// <param name="maxSize"></param>
    /// <returns></returns>
    public static string GetAlphabetic(int minSize, int maxSize)
    {
        return GetAlphabetic(rand.Next(minSize, maxSize));
    }

    /// <summary>
    /// returns a random sequence of characters with an ammount of specific characters types
    /// </summary>
    /// <param name="size"></param>
    /// <param name="minNumbers"></param>
    /// <param name="minUpperChars"></param>
    /// <param name="minLowerChars"></param>
    /// <param name="minSymbolChars"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
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