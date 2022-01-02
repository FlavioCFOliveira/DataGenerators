namespace Xumiga.DataGenerator.tests
{
    using System;
    using Xumiga.DataGenerators;
    using Xunit;

    public class MACAddressGeneratorTests
    {
        private const string HEX_CHARS = "0123456789abcdef";


        [Fact]
        public void MACAddressGenerator_Generate_SUCCESS()
        {
            var generated = MACAddressGenerator.Generate();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == 17);

            foreach (char c in generated)
            {
                if (c != ':')
                {
                    Assert.Contains(c, HEX_CHARS);
                }
            }

        }

        [Fact]
        public void MACAddressGenerator_Generate_WithSeparator_SUCCESS()
        {
            // Generate MAC address forcing the ':' separator char
            var generated = MACAddressGenerator.Generate(":");

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == 17);

            Assert.True(generated[2] == ':');
            Assert.True(generated[5] == ':');
            Assert.True(generated[8] == ':');
            Assert.True(generated[11] == ':');
            Assert.True(generated[14] == ':');


            // Generate MAC address forcing the '-' separator char
            var generatedDash = MACAddressGenerator.Generate("-");

            Assert.NotNull(generatedDash);
            Assert.NotEmpty(generatedDash);
            Assert.True(generatedDash.Length == 17);

            Assert.True(generatedDash[2] == '-');
            Assert.True(generatedDash[5] == '-');
            Assert.True(generatedDash[8] == '-');
            Assert.True(generatedDash[11] == '-');
            Assert.True(generatedDash[14] == '-');


            // Generate MAC address forcing no separator char
            var generatedNoSeparator = MACAddressGenerator.Generate(string.Empty);

            Assert.NotNull(generatedNoSeparator);
            Assert.NotEmpty(generatedNoSeparator);
            Assert.True(generatedNoSeparator.Length == 12);

        }

        [Fact]
        public void MACAddressGenerator_Generate_WithNullSeparator_SUCCESS()
        {
            var generated = MACAddressGenerator.Generate(null);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == 12);

        }

        [Fact]
        public void MACAddressGenerator_Generate_InvalidSeparator_ERROR()
        {

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                var generated = MACAddressGenerator.Generate("*");
            });

            Assert.StartsWith("Invalid separator character", ex.Message);

        }

    }
}