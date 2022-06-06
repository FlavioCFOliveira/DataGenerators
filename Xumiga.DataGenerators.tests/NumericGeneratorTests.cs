using Xumiga.DataGenerators;
using Xunit;

namespace Xumiga.DataGenerator.tests;

public class NumericGeneratorTests
{
    [Fact]
    public void GenerateDecimal_FixedSize_SUCCESS()
    {
        var lst = new List<decimal>();

        for (int i = 0; i < 1000; i++)
        {
            lst.Add(NumericGenerator.GenerateDecimal(8, 2));
        }

    }


    [Fact]
    public void GenerateShort_SUCCESS()
    {
        for (int i = 0; i < 5000; i++)
        {
            var n = NumericGenerator.GenerateShort();
            Assert.True(n >= short.MinValue && n <= short.MaxValue);
        }
    }

}