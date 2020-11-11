using System;
using Xunit;
using Xumiga.DataGenerators;
using System.Collections.Generic;
using System.Linq;

namespace Xumiga.DataGenerator.tests
{
    public class BooleanGeneratorTests
    {

        [Fact]
        public void BooleanGenerator_GetRandomName()
        {
            var container = new List<bool>();

            for (int i = 0; i < 100; i++)
            {
                container.Add(BooleanGenerator.GetRandom());
            }

            var countTrue = container.Where(v => v == true).Count();
            Assert.True(countTrue>0);

            var countFalse= container.Where(v => v == false).Count();
            Assert.True(countFalse > 0);

        }

    }
}
