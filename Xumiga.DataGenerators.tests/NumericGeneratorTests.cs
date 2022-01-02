using System;
using System.Collections.Generic;
using Xumiga.DataGenerators;
using Xunit;

namespace Xumiga.DataGenerator.tests
{
    public class NumericGeneratorTests
    {

        [Fact]
        public void NumericGeneratorTestsTests_GenerateDecimal_FixedSize_SUCCESS()
        {
            var lst = new List<decimal>();

            for (int i = 0; i < 1000; i++)
            {
                lst.Add(NumericGenerator.GenerateDecimal(8, 2));
            }
        }




    }
}
