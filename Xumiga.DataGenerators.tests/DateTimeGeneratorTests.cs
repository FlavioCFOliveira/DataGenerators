using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class DateTimeGeneratorTests
    {

        [Fact]
        public void DateTimeGenerator_Generate_50X_SUCCESS()
        {

            for (int i = 0; i < 50; i++)
            {
                DateTime generated = DateTimeGenerator.Generate();
                Assert.NotEqual(new DateTime(), generated);
            }
        }

    }
}
