﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public class IPAddressGenerator
    {

        static IPAddressGenerator()
        {
            rand = new Random();
        }

        public static Random rand;




        public static string GenerateIPV4Address()
        {
            var o1 = (byte)rand.Next(byte.MinValue, byte.MaxValue);
            var o2 = (byte)rand.Next(byte.MinValue, byte.MaxValue);
            var o3 = (byte)rand.Next(byte.MinValue, byte.MaxValue);
            var o4 = (byte)rand.Next(byte.MinValue, byte.MaxValue);

            return GetIPV4Address(o1, o2, o3, o4);
        }

        public static string GenerateIPV6Address()
        {
            var h1 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h2 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h3 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h4 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h5 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h6 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h7 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);
            var h8 = (UInt16)rand.Next(UInt16.MinValue, UInt16.MaxValue);

            return GetIPV6Address(h1, h2, h3, h4, h5, h6, h7, h8);
        }



        private static string GetIPV4Address(byte octet1 = 0, byte octet2 = 0, byte octet3 = 0, byte octet4 = 0)
        {
            return $"{octet1}.{octet2}.{octet3}.{octet4}";
        }
        private static string GetIPV6Address(UInt16 hextet1 = 0, UInt16 hextet2 = 0, UInt16 hextet3 = 0, UInt16 hextet4 = 0, UInt16 hextet5 = 0, UInt16 hextet6 = 0, UInt16 hextet7 = 0, UInt16 hextet8 = 0)
        {
            return $"{hextet1.ToString("X")}:{hextet2.ToString("X")}:{hextet3.ToString("X")}:{hextet4.ToString("X")}:{hextet5.ToString("X")}:{hextet6.ToString("X")}:{hextet7.ToString("X")}:{hextet8.ToString("X")}";
        }

    }
}
