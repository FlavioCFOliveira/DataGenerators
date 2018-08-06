using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class HexadecimalColorGeneratorTests
    {
        const string HEXA_CHARS = "0123456789abcdef";

        [Fact]
        public void HexadecimalColorGenerator_Generate_SUCCESS()
        {
            string generated = HexadecimalColorGenerator.Generate();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            Assert.StartsWith("#", generated);
            Assert.True(generated.Length == 7);

            for (int i = 1; i < generated.Length; i++)
            {
                Assert.True(HEXA_CHARS.Contains(generated[i]));
            }

        }

    }
}
