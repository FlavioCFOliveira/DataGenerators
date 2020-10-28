# RandomEnumGenerator
The RandomEnumGenerator has a single static method **```GetRandom()```** that returns a random value of a given Enum.

**Example**

```c#
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.Tests
{
    public class MyTestsExamples
    {
        [Fact]
        public void RandomEnumGenerator_SUCCESS()
        {
            int numberOfChars = 32;

            // Generate a string with a fixed amount of chars
            string generated = StringGenerator.GetAlphabetic(numberOfChars);

            // has result
            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            // correct ammount of chars
            Assert.True(generated.Length == numberOfChars);

        }
    }
}
```