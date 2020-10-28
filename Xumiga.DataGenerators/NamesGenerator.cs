using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Xumiga.DataGenerators
{
    public class NamesGenerator
    {
        static NamesGenerator()
        {
            rand = new Random();

            var aaa = Assembly.Load(new AssemblyName("Xumiga.DataGenerators"));

            Apelidos = new List<string>();
            var apleidos = aaa.GetManifestResourceNames().Where(n => n.EndsWith("Apelidos.txt")).FirstOrDefault();
            using (var sr = new StreamReader(aaa.GetManifestResourceStream(apleidos)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Apelidos.Add(line);
                }
            }

            NomesProprios = new List<string>();
            var nomesProprios = aaa.GetManifestResourceNames().Where(n => n.EndsWith("NomesProprios.txt")).FirstOrDefault();
            using (var sr = new StreamReader(aaa.GetManifestResourceStream(nomesProprios)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    NomesProprios.Add(line);
                }
                NomesProprios.Sort();
            }

        }

        public static Random rand;
        private static List<string> Apelidos;
        private static List<string> NomesProprios;


        public static string GetRandomName()
        {
            return NomesProprios[rand.Next(0, NomesProprios.Count - 1)];
        }
        public static string GetRandomSurname()
        {
            return Apelidos[rand.Next(0, Apelidos.Count - 1)];
        }

        public static string GetRandomFullName(int names = 2, int surnames = 2)
        {
            List<string> lst = new List<string>();

            for (int i = 0; i < names; i++)
            {
                lst.Add(GetRandomName());
            }

            for (int i = 0; i < surnames; i++)
            {
                lst.Add(GetRandomSurname());
            }

            return string.Join(" ", lst);
        }


    }
}
