using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class EmailGeneratorTests
    {

        [Fact]
        public void EmailGenerator_GenerateEmail_SUCCESS()
        {
            string generated = EmailGenerator.GenerateEmailAddress();

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }

        [Fact]
        public void EmailGenerator_GenerateEmailAddressWithWords_SUCCESS()
        {
            int numberOfWords = 3;
            string wordSeparator = ".";

            string generated = EmailGenerator.GenerateEmailAddressWithWords(numberOfWords, wordSeparator);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }
        
    }
}
