using System;
using Xunit;
using Xumiga.DataGenerators;
using System.Net.Mail;

namespace Xumiga.DataGenerator.tests
{
    public class HexadecimalGeneratorTests
    {
        private const string HEXA_CHARS = @"0123456789ABCDEF";

        [Fact]
        public void HexadecimalGenerator_Generate_SUCCESS()
        {
            string generated = HexadecimalGenerator.Generate(8);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            for (int i = 0; i < generated.Length; i++)
            {
                Assert.True(HEXA_CHARS.Contains(generated[i]));
            }

        }




    }
}
