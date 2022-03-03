using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Xumiga.DataGenerators;

public class NamesGenerator
{
    private static readonly Random rand;
    private static readonly List<string> Apelidos;
    private static readonly List<string> NomesProprios;

    static NamesGenerator()
    {
        rand = new Random();

        var ass = Assembly.Load(new AssemblyName("Xumiga.DataGenerators"));


        Apelidos = new List<string>();
        var apleidos = ass.GetManifestResourceNames().Where(n => n.EndsWith("Apelidos.txt")).FirstOrDefault();
        using (var sr = new StreamReader(ass.GetManifestResourceStream(apleidos)))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Apelidos.Add(line);
            }
        }

        NomesProprios = new List<string>();
        var nomesProprios = ass.GetManifestResourceNames().Where(n => n.EndsWith("NomesProprios.txt")).FirstOrDefault();
        using (var sr = new StreamReader(ass.GetManifestResourceStream(nomesProprios)))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                NomesProprios.Add(line);
            }
            NomesProprios.Sort();
        }

    }

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