using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static Dictionary<int, string> potion = new Dictionary<int, string>();

    static void Main(string[] args)
    {
        
        string[] lines = File.ReadAllLines(@"E:\Temp\input\input10.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            potion[i + 1] = lines[i].Replace("\n", "");
        }

        foreach (var key in potion.Keys.ToList())
        {
            potion[key] = Regex.Replace(potion[key], @"\b\d+\b", ReplaceKey);
            if (potion[key].Contains("WATER "))
            {
                potion[key] = "WT" + potion[key].Replace("WATER", "") + " TW";
            }
            if (potion[key].Contains("DUST "))
            {
                potion[key] = "DT" + potion[key].Replace("DUST", "") + " TD";
            }
            if (potion[key].Contains("MIX "))
            {
                potion[key] = "MX" + potion[key].Replace("MIX", "") + " XM";
            }
            if (potion[key].Contains("FIRE "))
            {
                potion[key] = "FR" + potion[key].Replace("FIRE", "") + " RF";
            }
        }

        Console.WriteLine(potion[lines.Length].Replace(" ", ""));
    }

    static string ReplaceKey(Match match)
    {
        int key = int.Parse(match.Value);
        return potion[key];
    }
}
