using System;
using System.Collections.Generic;
using System.Text;

namespace Xumiga.DataGenerators
{
    public static class RandomEnumGenerator
    {
        static RandomEnumGenerator()
        {
            rand = new Random();
        }

        public static Random rand;

        public static T GetRandom<T>() where T: IConvertible
        {
            var items = Enum.GetNames(typeof(T));
            
            var rnd = rand.Next(items.Length);

            return (T)Enum.Parse(typeof(T), items[rnd]);
        }


    }
}
