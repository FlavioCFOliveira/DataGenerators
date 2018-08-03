using System;
using System.Collections.Generic;
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

    }
}
