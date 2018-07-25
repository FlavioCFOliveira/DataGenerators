using System;
using Xunit;
using Xumiga.DataGenerators;
using System.Net.Mail;
using System.Globalization;

namespace Xumiga.DataGenerator.tests
{
    public class IPAddressGeneratorTests
    {
        private const string HEXA_CHARS = @"0123456789ABCDEF";

        [Fact]
        public void IPAddressGenerator_GenerateIPV4Address_SUCCESS()
        {
            string generated = IPAddressGenerator.GenerateIPV4Address();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            string[] splited = generated.Split('.');

            Assert.True(splited.Length == 4);

            byte octet;
            for (int i = 0; i < splited.Length; i++)
            {
                Assert.True(byte.TryParse(splited[i], out octet));
            }

        }

        [Fact]
        public void IPAddressGenerator_GenerateIPV6Address_SUCCESS()
        {
            string generated = IPAddressGenerator.GenerateIPV6Address();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            string[] splited = generated.Split(':');

            Assert.True(splited.Length == 8);

            ushort hextet;
            for (int i = 0; i < splited.Length; i++)
            {
                Assert.True(ushort.TryParse(splited[i], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hextet));
            }

        }

    }
}
