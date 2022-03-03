using System;
using System.Linq;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator for Hexadecimal character sequences
/// </summary>
public static class HexadecimalGenerator
{
    private static readonly Random rand;
    private const string HEXA_CHARS = @"0123456789abcdef";

    static HexadecimalGenerator()
    {
        rand = new Random();
    }

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

    /// <summary>
    /// Generates a random string representing a color in hexadecimal format
    /// </summary>
    /// <returns>Hexadecimal color in the format #AAAAAA</returns>
    public static string GenerateColor()
    {
        byte[] buffer = new byte[3];
        rand.NextBytes(buffer);

        string[] hexBuffer = buffer.Select(b => b.ToString("x2")).ToArray();

        return $"#{string.Join(string.Empty, hexBuffer)}";
    }

}