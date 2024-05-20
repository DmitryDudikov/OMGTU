using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> usedSymbols = new Dictionary<char, int>();
        StreamReader file = new StreamReader(@"C:\Users\kiril\OneDrive\Рабочий стол\ТестФайл.txt");
        while (true)
        {
            string data = file.ReadLine();
            if (data != null)
            {
                foreach (char d in data)
                {
                    if (usedSymbols.ContainsKey(d))
                    {
                        usedSymbols[d] += 1;
                    }
                    else { usedSymbols.Add(d, 1); }
                }
            }
            else { break; }
        }

        int maxCount = 0;
        char mostOften = ' ';
        foreach (var symb in usedSymbols.Keys)
        {
            if (usedSymbols[symb] > maxCount)
            {
                maxCount = usedSymbols[symb];
                mostOften = symb;
            }
        }
        Console.WriteLine("Символ, который встречается чаще всего: " + mostOften);

        var used = usedSymbols.Keys.OrderBy(x => x);

        Console.WriteLine("Всего использовано символов: " + Convert.ToString(usedSymbols.Keys.Count));

        Console.Write("Список символов: ");
        foreach (var s in used)
        {
            Console.Write(s + " ");
        }
        Console.ReadKey();
    }
}
