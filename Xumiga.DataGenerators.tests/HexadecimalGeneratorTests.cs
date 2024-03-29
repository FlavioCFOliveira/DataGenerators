namespace Xumiga.DataGenerator.tests
{
    using Xumiga.DataGenerators;
    using Xunit;

    public class HexadecimalGeneratorTests
    {
        private const string HEXA_CHARS = @"0123456789abcdef";

        [Fact]
        public void HexadecimalGenerator_Generate_SUCCESS()
        {
            string generated = HexadecimalGenerator.Generate(8);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            for (int i = 0; i < generated.Length; i++)
            {
                Assert.Contains(generated[i], HEXA_CHARS);
            }

        }

        [Fact]
        public void HexadecimalGenerator_GenerateColor_SUCCESS()
        {
            string generated = HexadecimalGenerator.GenerateColor();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            Assert.StartsWith("#", generated);
            Assert.True(generated.Length == 7);

            for (int i = 1; i < generated.Length; i++)
            {
                Assert.Contains(generated[i], HEXA_CHARS);
            }

        }

    }
}
