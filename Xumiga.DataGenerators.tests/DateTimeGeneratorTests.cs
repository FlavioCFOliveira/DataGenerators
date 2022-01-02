namespace Xumiga.DataGenerator.tests
{
    using System;
    using Xumiga.DataGenerators;
    using Xunit;

    public class DateTimeGeneratorTests
    {
        [Fact]
        public void DateTimeGenerator_GenerateDateTime_50X_SUCCESS()
        {
            for (int i = 0; i < 50; i++)
            {
                DateTime generated = DateTimeGenerator.GenerateDateTime();
                Assert.NotEqual(new DateTime(), generated);
            }
        }

        [Fact]
        public void DateTimeGenerator_GenerateDateTime_Ranged_50X_SUCCESS()
        {
            var startDate = DateTime.Now;
            var endtDate = startDate.AddYears(2);

            for (int i = 0; i < 50; i++)
            {
                DateTime generated = DateTimeGenerator.GenerateDateTime(startDate, endtDate);
                Assert.NotEqual(new DateTime(), generated);
                Assert.InRange(generated, startDate, endtDate);
            }

        }

        [Fact]
        public void DateTimeGenerator_GenerateDateTime_ArgumentException_MinMax()
        {
            var startDate = DateTime.Now;
            var endtDate = startDate.AddYears(2);

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                DateTime generated = DateTimeGenerator.GenerateDateTime(endtDate, startDate);
            });

            Assert.StartsWith("Minimum date should be lower than maximum date", ex.Message);
        }

        [Fact]
        public void DateTimeGenerator_GenerateDateTime_ArgumentException_EqualDates()
        {
            var startDate = DateTime.Now;

            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                DateTime generated = DateTimeGenerator.GenerateDateTime(startDate, startDate);
            });

            Assert.StartsWith("Cannot generate a random date between do equal dates", ex.Message);
        }
    }
}