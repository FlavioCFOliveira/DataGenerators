namespace Xumiga.DataGenerators
{
    public static class BooleanGenerator
    {
        public static bool GetRandom()
        {
            return (NumericGenerator.GenerateInteger(0, 1) == 1);
        }
    }
}