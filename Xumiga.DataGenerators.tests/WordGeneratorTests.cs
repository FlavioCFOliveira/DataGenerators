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
            int numberOfWords = 200;

            string[] generated = WordGenerator.GenerateWords(numberOfWords);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == numberOfWords);

        }

        [Fact]
        public void WordGenerator_GenerateWords_FixedNumberSizeRange_SUCCESS()
        {
            int numberOfWords = 100;
            int minWordSize = 2;
            int maxWordSize = 14;

            string[] generated = WordGenerator.GenerateWords(numberOfWords, minWordSize, maxWordSize);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == numberOfWords);

            foreach (var word in generated)
            {
                Assert.True((word.Length >= minWordSize) && (word.Length <= maxWordSize));
            }

        }


        [Fact]
        public void WordGenerator_GenerateWord_RandomSize_SUCCESS()
        {
            int minWordSize = 2;
            int maxWordSize = 14;

            string generated = WordGenerator.GenerateWord(minWordSize, maxWordSize);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True((generated.Length >= minWordSize) && (generated.Length <= maxWordSize));

        }

        [Fact]
        public void WordGenerator_GenerateWord_FixedSize_SUCCESS()
        {
            int wordSize = 10;

            string generated = WordGenerator.GenerateWord(wordSize);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);
            Assert.True(generated.Length == wordSize);

        }



    }
}
