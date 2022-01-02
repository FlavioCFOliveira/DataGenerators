namespace Xumiga.DataGenerators
{
    using System;

    public static class RandomEnumGenerator
    {
        public static readonly Random rand;

        static RandomEnumGenerator()
        {
            rand = new Random();
        }

        public static T GetRandom<T>() where T : IConvertible
        {
            var items = Enum.GetNames(typeof(T));

            var rnd = rand.Next(items.Length);

            return (T)Enum.Parse(typeof(T), items[rnd]);
        }

    }
}