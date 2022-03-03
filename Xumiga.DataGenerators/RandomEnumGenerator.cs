using System;

namespace Xumiga.DataGenerators;

/// <summary>
/// Random generator of values based on a enum
/// </summary>
public static class RandomEnumGenerator
{
    private static readonly Random rand;
    static RandomEnumGenerator()
    {
        rand = new Random();
    }

    /// <summary>
    /// Select a random value of a enum
    /// </summary>
    /// <typeparam name="T">enum type</typeparam>
    /// <returns>a random enum value</returns>
    public static T GetRandom<T>() where T : IConvertible
    {
        var items = Enum.GetNames(typeof(T));

        var rnd = rand.Next(items.Length);

        return (T)Enum.Parse(typeof(T), items[rnd]);
    }

}