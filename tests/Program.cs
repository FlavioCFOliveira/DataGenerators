using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = TestingTools.NIFGenerator.GenerateNIF();

            FixedSizeStrings();

            RandomSizeStrings();

            FixedSizeStrongStrings();

            GetMaskedAlphaNumeric();

            GenerateNIF();

            Console.ReadKey();
        }


        static void FixedSizeStrings()
        {
            Console.WriteLine("Generating 20 fixed size alfanumeric strings with 30 chars:");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"  [{i}]-> " + TestingTools.StringGenerator.GetAlphaNumeric(17));
            }

        }

        static void GetMaskedAlphaNumeric()
        {
            // JM1FE17N340134462
            string mask = "AANAANNANNNNNNNNN";
            Console.WriteLine($"Generating masked Alfanumeric Strings: MASK-> {mask}");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"  [{i}]-> " + TestingTools.StringGenerator.GetMaskedAlphaNumeric(mask));
            }

        }


        static void RandomSizeStrings()
        {
            Console.WriteLine("Generating 20 random sized alfanumeric strings with ramdom sizes between 3 and 50 chars:");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"  [{i}]-> " + TestingTools.StringGenerator.GetAlphaNumeric(3, 50));
            }

        }

        static void FixedSizeStrongStrings()
        {
            Console.WriteLine("Generating 20 fixed sized strong strings:");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"  [{i}]-> " + TestingTools.StringGenerator.GenerateStrongString(12, 1, 1, 1, 1));
            }

        }


        static void GenerateNIF()
        {
            Console.WriteLine("Generating 20 NIF's:");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"  [{i}]-> " + TestingTools.NIFGenerator.GenerateNIF(TestingTools.NIFType.PessoaSingular));
            }
        }

    }
}
