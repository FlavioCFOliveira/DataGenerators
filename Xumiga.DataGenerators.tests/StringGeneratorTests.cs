using System;
using Xumiga.DataGenerators;
using Xunit;

namespace Xumiga.DataGenerator.tests
{
    public class StringGeneratorTests
    {
        private const string ALPHABETIC_CHARS = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        [Fact]
        public void StringGenerator_GetAlphabetic_FixedSize_SUCCESS()
        {

            Random rand = new Random();
            int numberOfChars = rand.Next(1, 200);

            // Generate a string with a fixed random amount of chars
            string generated = StringGenerator.GetAlphabetic(numberOfChars);

            // has result
            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            // correct ammount of chars
            Assert.True(generated.Length == numberOfChars);

            // all chars are valid
            foreach (char c in generated)
            {
                Assert.Contains(c, ALPHABETIC_CHARS);
            }

        }

    }
}
