using System;
using Xunit;
using Xumiga.DataGenerators;

namespace Xumiga.DataGenerator.tests
{
    public class NIFGeneratorTests
    {

        [Fact]
        public void NIFGenerator_PessoaSingular_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.PessoaSingular);

            Assert.True(generated.StartsWith("1") || generated.StartsWith("2") || generated.StartsWith("3"));

            CommonTestsRules(generated);
        }





        /// <summary>
        /// All the generated results must follow the same rules
        /// </summary>
        /// <param name="nif"></param>
        private void CommonTestsRules(string nif)
        {
            Assert.NotNull(nif);

            Assert.True(nif.Length == 9);

            for (int i = 0; i < nif.Length; i++)
            {
                Assert.True(Char.IsNumber(nif[i]));
            }

            int checkDigit = GetCheckDigit(nif.Substring(0,8));
            int lastDigit = int.Parse(nif.Substring(8));

            Assert.Equal(checkDigit, lastDigit);

        }

        /// <summary>
        /// Calculate the checkdigit
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private int GetCheckDigit(string number)
        {
            byte[] multiplyValues = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2 };
            int Total = 0;
            int checkDigit = 0;

            for (int i = 0; i < number.Length; i++)
            {
                byte b = byte.Parse(number[i].ToString());
                int multiplyResult = b * multiplyValues[i];
                Total += multiplyResult;
            }

            int resto = Total % 11;

            if (resto == 0 || resto == 1)
            {
                checkDigit = 0;
            }
            else
            {
                checkDigit = (11 - resto);
            }

            return checkDigit;
        }
    }
}
