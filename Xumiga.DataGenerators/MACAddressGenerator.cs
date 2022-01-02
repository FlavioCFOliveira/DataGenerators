namespace Xumiga.DataGenerators
{
    using System;
    using System.Linq;

    public static class MACAddressGenerator
    {
        public static readonly Random rand;

        static MACAddressGenerator()
        {
            rand = new Random();
        }

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
}
