using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class WordGeneratorTests
    {

        [Fact]
        public void WordGenerator_GenerateWords_FixedNumber_SUCCESS()
        {
            string[] generated = WordGenerator.GenerateWords(10);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }

        [Fact]
        public void WordGenerator_GenerateWords_FixedNumberSizeRange_SUCCESS()
        {

            string[] generated = WordGenerator.GenerateWords(10, 2, 18);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }


        [Fact]
        public void WordGenerator_GenerateWord_RandomSize_SUCCESS()
        {
            string generated = WordGenerator.GenerateWord(3, 16);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }

        [Fact]
        public void WordGenerator_GenerateWord_FixedSize_SUCCESS()
        {

            string generated = WordGenerator.GenerateWord(10);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

        }



    }
}
