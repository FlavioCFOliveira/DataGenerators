using System;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator of portuguese valid nif/tax number
/// </summary>
public static class NIFGenerator
{
    private static readonly Random rand;
    static NIFGenerator()
    {
        rand = new Random();
    }

    /// <summary>
    /// Generates a random valid nif / tax number
    /// </summary>
    /// <returns></returns>
    public static string GenerateNIF()
    {
        NIFType randdomType = NIFType.PessoaSingular;

        var values = Enum.GetValues(typeof(NIFType));
        int rPosition = rand.Next(0, values.Length - 1);

        randdomType = (NIFType)values.GetValue(rPosition);

        return GenerateNIF(randdomType);
    }

    /// <summary>
    /// Generates a random valid nif / tax number of a specific type
    /// </summary>
    /// <param name="t">the type of nif to be generated</param>
    /// <returns></returns>
    public static string GenerateNIF(NIFType t)
    {
        string number = string.Empty;
        string checkDigit = string.Empty;

        // RANDOM NUMBER GENERATION
        switch (t)
        {
            case NIFType.PessoaSingular: number = "1" + StringGenerator.GetNumeric(7); break;
            case NIFType.PessoaSingularEstrangeiro: number = "45" + StringGenerator.GetNumeric(6); break;
            case NIFType.PessoaColectiva: number = "5" + StringGenerator.GetNumeric(7); break;
            case NIFType.AdministracaoPublica: number = "6" + StringGenerator.GetNumeric(7); break;
            case NIFType.HerancaIndivisa: number = "70" + StringGenerator.GetNumeric(6); break;
            case NIFType.NaoResidentesColectivos: number = "71" + StringGenerator.GetNumeric(6); break;
            case NIFType.FundosDeInvestimento: number = "72" + StringGenerator.GetNumeric(6); break;
            case NIFType.AtribuicaoOficiosaSujeitoPassivo: number = "77" + StringGenerator.GetNumeric(6); break;
            case NIFType.AtribuicaoOficiosaNaoResidentes: number = "78" + StringGenerator.GetNumeric(6); break;
            case NIFType.RegimeExcepcional: number = "79" + StringGenerator.GetNumeric(6); break;
            case NIFType.EmpresarioEmNomeIndividual: number = "8" + StringGenerator.GetNumeric(7); break;
            case NIFType.Condominios: number = "90" + StringGenerator.GetNumeric(6); break;
            case NIFType.NaoResidentes: number = "98" + StringGenerator.GetNumeric(6); break;
            case NIFType.SemPersonalidadeJuridica: number = "99" + StringGenerator.GetNumeric(6); break;
            default: number = "1" + StringGenerator.GetNumeric(7); break;
        }

        // CHECK DIGIT
        byte[] multiplyValues = new byte[] { 9, 8, 7, 6, 5, 4, 3, 2 };
        int Total = 0;

        for (int i = 0; i < number.Length; i++)
        {
            byte b = byte.Parse(number[i].ToString());
            int multiplyResult = b * multiplyValues[i];
            Total += multiplyResult;
        }

        int resto = Total % 11;

        if (resto == 0 || resto == 1)
        {
            checkDigit = "0";
        }
        else
        {
            checkDigit = (11 - resto).ToString();
        }

        return $"{number}{checkDigit}";
    }

}

/// <summary>
/// Possible portuguese nif /tax number types
/// </summary>
public enum NIFType : int
{

    /// <summary>
    ///1 a 3: Pessoa singular, o 3 ainda não está atribuido;[2] 
    /// </summary>
    PessoaSingular = 1,

    /// <summary>
    /// 45: Pessoa singular. Os algarismos iniciais "45" correspondem aos cidadãos não residentes que apenas obtenham em território português rendimentos sujeitos a retenção na fonte a título definitivo;[2]
    /// </summary>
    PessoaSingularEstrangeiro = 2,

    /// <summary>
    /// 5: Pessoa colectiva obrigada a registo no Registo Nacional de Pessoas Colectivas;[3]
    /// </summary>
    PessoaColectiva = 3,

    /// <summary>
    /// 6: Organismo da Administração Pública Central, Regional ou Local;
    /// </summary>
    AdministracaoPublica = 4,

    /// <summary>
    /// 70, 74 e 75: Herança Indivisa, em que o autor da sucessão não era empresário individual, ou Herança Indivisa em que o cônjuge sobrevivo tem rendimentos comerciais;
    /// </summary>
    HerancaIndivisa = 5,

    /// <summary>
    /// 71: Não residentes colectivos sujeitos a retenção na fonte a título definitivo;
    /// </summary>
    NaoResidentesColectivos = 6,

    /// <summary>
    /// 72: Fundos de investimento;
    /// </summary>
    FundosDeInvestimento = 7,

    /// <summary>
    /// 77: Atribuição Oficiosa de NIF de sujeito passivo (entidades que não requerem NIF junto do RNPC);
    /// </summary>
    AtribuicaoOficiosaSujeitoPassivo = 8,

    /// <summary>
    /// 78: Atribuição oficiosa a não residentes abrangidos pelo processo VAT REFUND;
    /// </summary>
    AtribuicaoOficiosaNaoResidentes = 9,

    /// <summary>
    /// 79: Regime excepcional - Expo 98;
    /// </summary>
    RegimeExcepcional = 10,

    /// <summary>
    /// 8: "empresário em nome individual" (actualmente obsoleto, já não é utilizado nem é válido);
    /// </summary>
    EmpresarioEmNomeIndividual = 11,

    /// <summary>
    /// 90 e 91: Condomínios, Sociedade Irregulares, Heranças Indivisas cujo autor da sucessão era empresário individual;
    /// </summary>
    Condominios = 12,

    /// <summary>
    /// 98: Não residentes sem estabelecimento estável;
    /// </summary>
    NaoResidentes = 13,

    /// <summary>
    /// 99: Sociedades civis sem personalidade jurídica.
    /// </summary>
    SemPersonalidadeJuridica = 14

}