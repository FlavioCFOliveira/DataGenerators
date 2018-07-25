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
        
    }
}
