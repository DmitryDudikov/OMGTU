using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static Dictionary<string, string> Persons = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"E:\Temp\input\input1.txt");
        HashSet<string> IDs = new HashSet<string>(lines.Take(lines.Length - 2).Select(line => line.Substring(0, 4)));
        List<Tuple<string, string>> Pers = new List<Tuple<string, string>>();

        for (int i = 0; i < lines.Length - 2; i++)
        {
            Pers.Add(new Tuple<string, string>(lines[i].Substring(0, 4), lines[i].Substring(5).TrimEnd()));
        }

        foreach (var id in IDs)
        {
            AddPerson(id, "Unknown Name");
            foreach (var p in Pers)
            {
                if (id == p.Item1 && !string.IsNullOrEmpty(p.Item2))
                {
                    AddPerson(id, p.Item2);
                }
            }
        }

        string master = lines.Last();
        if (!master.All(char.IsDigit))
        {
            foreach (var p in Pers)
            {
                if (p.Item2 == master)
                {
                    master = p.Item1;
                    break;
                }
            }
        }

        HashSet<string> masterSlaves = FindSlaves(master, Pers);
        HashSet<string> newSlaves = new HashSet<string>();

        while (true)
        {
            int lens = masterSlaves.Count;
            foreach (var slave in masterSlaves)
            {
                newSlaves.UnionWith(FindSlaves(slave, Pers));
            }
            masterSlaves.UnionWith(newSlaves);
            if (masterSlaves.Count == lens)
            {
                break;
            }
        }

        masterSlaves = new HashSet<string>(masterSlaves.OrderBy(slave => slave));
        if (!masterSlaves.Any())
        {
            Console.WriteLine("NO");
        }
        else
        {
            foreach (var slave in masterSlaves)
            {
                Console.WriteLine($"{slave} {Persons[slave]}");
            }
        }
    }

    static void AddPerson(string num, string name)
    {
        Persons[num] = name;
    }

    static HashSet<string> FindSlaves(string master, List<Tuple<string, string>> baseList)
    {
        HashSet<string> slaves = new HashSet<string>();
        for (int i = 0; i < baseList.Count - 1; i++)
        {
            if (i % 2 == 0 && baseList[i].Item1 == master)
            {
                slaves.Add(baseList[i + 1].Item1);
            }
        }
        return slaves;
    }
}
