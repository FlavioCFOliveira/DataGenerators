using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xumiga.DataGenerators
{
    //https://en.wikipedia.org/wiki/MAC_address
    public static class MACAddressGenerator
    {
        static MACAddressGenerator()
        {
            rand = new Random();
        }
        public static Random rand;


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
