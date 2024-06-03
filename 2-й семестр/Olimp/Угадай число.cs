using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"E\Temp\input\input1.txt");

        for (int x = -100; x <= 100; x++)
        {
            int t = x;
            for (int i = 1; i < lines.Length - 1; i++)
            {
                t = Fokus(t, lines[i], x);
            }
            if (t == int.Parse(lines[lines.Length - 1]))
            {
                Console.WriteLine(x);
                break;
            }
        }
    }

    static int Fokus(int num, string strk, int x)
    {
        string[] parts = strk.Split();
        string v = parts[0];
        string n = parts[1] == "x" ? x.ToString() : parts[1];

        int nInt = int.Parse(n);

        return v switch
        {
            "+" => num + nInt,
            "-" => num - nInt,
            "*" => num * nInt,
            "/" => num / nInt,
            _ => num
        };
    }
}
