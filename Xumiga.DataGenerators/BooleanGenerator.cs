using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{

    public static class BooleanGenerator
    {        
        public static bool GetRandom()
        {
            return (NumericGenerator.GenerateInteger(0, 1) == 1);
        }
    }
}
