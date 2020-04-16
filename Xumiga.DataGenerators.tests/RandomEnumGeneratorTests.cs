using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class RandomEnumGeneratorTests
    {

        public enum TestOptions : int
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5,
        }

        [Fact]
        public void RandomEnumGenerator_SUCCESS()
        {
            for (int i = 0; i < 50; i++)
            {
                var actual = RandomEnumGenerator.GetRandom<TestOptions>();
                Assert.True(Enum.IsDefined(typeof(TestOptions), actual));
            }
        }

    }
}
