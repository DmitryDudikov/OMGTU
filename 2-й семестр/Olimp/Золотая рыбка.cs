using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static (int, List<string>, List<string[]>, List<string[]>) GetInfo(string path)
    {
        using (StreamReader f = new StreamReader(path))
        {
            int countWords = int.Parse(f.ReadLine().Trim());
            List<string> words = new List<string>();
            for (int i = 0; i < countWords; i++)
            {
                words.Add(f.ReadLine().Trim());
            }

            int countStarts = int.Parse(f.ReadLine().Trim());
            List<string[]> starts = new List<string[]>();
            for (int i = 0; i < countStarts; i++)
            {
                starts.Add(f.ReadLine().Trim().Split());
            }

            int countEnds = int.Parse(f.ReadLine().Trim());
            List<string[]> ends = new List<string[]>();
            for (int i = 0; i < countEnds; i++)
            {
                ends.Add(f.ReadLine().Trim().Split());
            }

            return (countWords, words, starts, ends);
        }
    }

    static void GetAnswer(string path)
    {
        var (n, words, starts, ends) = GetInfo(path);
        List<string> way1 = new List<string>();
        List<string> way2 = new List<string>();

        foreach (var word in words)
        {
            foreach (var start in starts)
            {
                foreach (var end in ends)
                {
                    if (word[0] == start[0][0] && word[^1] == end[0][0])
                    {
                        if (int.Parse(start[1]) > 0 && int.Parse(end[1]) > 0)
                        {
                            way1.Add(word);
                            start[1] = (int.Parse(start[1]) - 1).ToString();
                            end[1] = (int.Parse(end[1]) - 1).ToString();
                        }
                    }
                }
            }
        }

        var (_, _, sortedStarts, sortedEnds) = GetInfo(path);
        sortedStarts.Sort((a, b) => int.Parse(b[1]).CompareTo(int.Parse(a[1])));
        sortedEnds.Sort((a, b) => int.Parse(b[1]).CompareTo(int.Parse(a[1])));

        foreach (var end in sortedEnds)
        {
            foreach (var start in sortedStarts)
            {
                foreach (var word in words)
                {
                    if (word[0] == start[0][0] && word[^1] == end[0][0])
                    {
                        if (int.Parse(start[1]) > 0 && int.Parse(end[1]) > 0)
                        {
                            way2.Add(word);
                            start[1] = (int.Parse(start[1]) - 1).ToString();
                        }
                    }
                }
            }
        }

        int myAnswer = Math.Max(way1.Count, way2.Count);
        Console.WriteLine(myAnswer);
    }

    static void Main()
    {
        GetAnswer(@"E\Temp\input\input1.txt");
    }
}
