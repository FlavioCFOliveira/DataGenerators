using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class EmailGeneratorTests
    {

        [Fact]
        public void EmailGenerator_GetEmail_SUCCESS()
        {
            var userName = StringGenerator.GetAlphabeticLower(24);
            var domainName = StringGenerator.GetAlphabeticLower(8);
            var domain = StringGenerator.GetAlphabeticLower(3);

            string generated = EmailGenerator.GetEmail(userName, domainName, domain);

            Assert.NotNull(generated);
            Assert.NotEmpty(generated);

            string expectedEmail = $"{userName}@{domainName}.{domain}";
            Assert.Equal(expectedEmail, generated);

        }

    }
}
