namespace Xumiga.DataGenerator.tests
{
    using Xumiga.DataGenerators;
    using Xunit;

    public class NamesGeneratorTests
    {

        [Fact]
        public void NamesGenerator_GetRandomName()
        {
            var val = NamesGenerator.GetRandomName();

            Assert.True(!string.IsNullOrEmpty(val));
        }

        [Fact]
        public void NamesGenerator_GetRandomSurname()
        {
            var val = NamesGenerator.GetRandomSurname();

            Assert.True(!string.IsNullOrEmpty(val));
        }


        [Fact]
        public void NamesGenerator_GetRandomFullName()
        {
            var val1 = NamesGenerator.GetRandomFullName();
            var val2 = NamesGenerator.GetRandomFullName(3, 3);
            var val3 = NamesGenerator.GetRandomFullName(10, 10);

            Assert.True(!string.IsNullOrEmpty(val1));
            Assert.True(!string.IsNullOrEmpty(val2));
            Assert.True(!string.IsNullOrEmpty(val3));
        }

    }
}