using System;
using System.Linq;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator for MAC Addresses formated character sequences
/// </summary>
public static class MACAddressGenerator
{
    private static readonly Random rand;

    static MACAddressGenerator()
    {
        rand = new Random();
    }

    /// <summary>
    /// Generate a random mac address
    /// </summary>
    /// <param name="separator">separator character</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string Generate(string separator = ":")
    {
        if (separator == null) separator = string.Empty;

        if (separator != ":" && separator != "-" && separator != "" && separator != string.Empty)
        {
            throw new ArgumentException("Invalid separator character", nameof(separator));
        }

        byte[] octets = new byte[6];
        rand.NextBytes(octets);

        string[] hexOctets = octets.Select(b => b.ToString("x2")).ToArray();

        return string.Join(separator, hexOctets);
    }

}