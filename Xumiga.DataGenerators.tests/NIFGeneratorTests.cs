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

        [Fact]
        public void NIFGenerator_PessoaSingularEstrangeiro_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.PessoaSingularEstrangeiro);

            Assert.StartsWith("45", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_PessoaColectiva_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.PessoaColectiva);

            Assert.StartsWith("5", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_AdministracaoPublica_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.AdministracaoPublica);

            Assert.StartsWith("6", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_HerancaIndivisa_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.HerancaIndivisa);

            Assert.True(generated.StartsWith("70") || generated.StartsWith("74") || generated.StartsWith("75"));

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_NaoResidentesColectivos_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.NaoResidentesColectivos);

            Assert.StartsWith("71", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_FundosDeInvestimento_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.FundosDeInvestimento);

            Assert.StartsWith("72", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_AtribuicaoOficiosaSujeitoPassivo_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.AtribuicaoOficiosaSujeitoPassivo);

            Assert.StartsWith("77", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_AtribuicaoOficiosaNaoResidentes_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.AtribuicaoOficiosaNaoResidentes);

            Assert.StartsWith("78", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_RegimeExcepcional_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.RegimeExcepcional);

            Assert.StartsWith("79", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_EmpresarioEmNomeIndividual_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.EmpresarioEmNomeIndividual);

            Assert.StartsWith("8", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_Condominios_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.Condominios);

            Assert.True(generated.StartsWith("90") || generated.StartsWith("91"));

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_NaoResidentes_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.NaoResidentes);

            Assert.StartsWith("98", generated);

            CommonTestsRules(generated);
        }

        [Fact]
        public void NIFGenerator_SemPersonalidadeJuridica_SUCCESS()
        {
            string generated = NIFGenerator.GenerateNIF(NIFType.SemPersonalidadeJuridica);

            Assert.StartsWith("99", generated);

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

            int checkDigit = GetCheckDigit(nif.Substring(0, 8));
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
