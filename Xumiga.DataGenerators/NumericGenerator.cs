using System;
using System.Globalization;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator for numeric values
/// </summary>
public static class NumericGenerator
{
    private static readonly Random rand;
    private static readonly NumberFormatInfo culture;

    static NumericGenerator()
    {
        rand = new Random();
        culture = NumberFormatInfo.CurrentInfo;
    }

    /// <summary>
    /// returns a random int number
    /// </summary>
    /// <returns></returns>
    public static int GenerateInteger()
    {
        return rand.Next();
    }

    /// <summary>
    /// returns a random int mumber below a givem value
    /// </summary>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static int GenerateInteger(int maxValue)
    {
        return rand.Next(maxValue + 1);
    }

    /// <summary>
    /// returns a random number between two numbers
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static int GenerateInteger(int minValue, int maxValue)
    {
        return rand.Next(minValue, maxValue + 1);
    }

    /// <summary>
    /// returns a ramdom byte
    /// </summary>
    /// <returns></returns>
    public static byte GenerateByte()
    {
        byte[] r = new byte[1];
        rand.NextBytes(r);

        return r[0];
    }

    /// <summary>
    /// returns a long / int64 number
    /// </summary>
    /// <returns></returns>
    public static long GenerateLong()
    {
        return rand.NextLong();
    }

    /// <summary>
    /// returns a long / int64 number below a guvem number
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    public static long GenerateLong(long max)
    {
        return rand.NextLong(max);
    }

    /// <summary>
    /// returns a long / int64 number between two numbers
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static long GenerateLong(long min, long max)
    {
        return rand.NextLong(min, max);
    }

    /// <summary>
    /// returns a short / int16 between two numbers
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static short GenerateShort(short minValue, short maxValue)
    {
        return (short)rand.Next((int)minValue, (int)maxValue);
    }

    /// <summary>
    /// returns a decimal value
    /// </summary>
    /// <param name="precision"></param>
    /// <param name="scale"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static decimal GenerateDecimal(int precision, int scale)
    {
        if (precision == 0) throw new Exception("precision must be greater than zero.");
        if (precision == scale) throw new Exception("precision and scale must have different values");
        if (precision < scale) throw new Exception("precision cannot be less than scale");

        int randPrecision = NumericGenerator.GenerateInteger(1, (precision - scale) + 1);
        var a = StringGenerator.GetNumeric(randPrecision);

        int randScale = NumericGenerator.GenerateInteger(1, scale + 1);
        var b = StringGenerator.GetNumeric(randScale);

        decimal result = decimal.Parse($"{a}{culture.NumberDecimalSeparator}{b}");

        return result;
    }

}