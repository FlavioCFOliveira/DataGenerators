# Xumiga Data Generators 
My main purpose for this project is to help creating random data for unit tests usage. 
This is a project that i'm developing as my dailly needs are dictated, but as i decided to meke it public your suggestions are very, very welcome.

**Example**

```c#
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.Tests
{
    public class MyTestsExamples
    {
        [Fact]
        public void StringGenerator_GetAlphabetic_FixedSize_SUCCESS()
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

Random data Generators
---
- **StringGenerator** - Generates a random sequences of characters 
- **WordGenerator** - Generates a random sequences of characters like words
- **DateTimeGenerator** - Generates a random date time 
- **EmailGenerator** - Generates a random email formated string 
- **HexadecimalGenerator** - Generates a random sequences of hexadecimal characters 
- **IPAddressGenerator** - Generates a random ip address
- **MACAddressGenerator** - Generates a random MAC address
- **NIFGenerator** - Generates a random valid Portuguese NIF
- **NumericGenerator** - Generates a random numbers
- [**RandomEnumGenerator**](docs/RandomEnumGenerator.md) - Gets a Random value from a given Enum

Documentation is being written...