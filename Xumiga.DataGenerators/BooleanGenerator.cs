namespace Xumiga.DataGenerators;

/// <summary>
/// Generator for random boolean values
/// </summary>
public static class BooleanGenerator
{
    /// <summary>
    /// Generates a random boolean value
    /// </summary>
    /// <returns>True or False</returns>
    public static bool GetRandom()
    {
        return (NumericGenerator.GenerateInteger(0, 1) == 1);
    }
}
